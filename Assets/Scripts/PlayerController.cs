using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace playerMovement 
{
    public class PlayerController : MonoBehaviour 
    {
        Animator animator;
        public ScoreController scoreController;
        public HealthController healthController;
        public GameOverController gameOverController;

        [SerializeField] private Rigidbody2D rb;
        [SerializeField] private BoxCollider2D box_collider;
        [SerializeField] private float speed;
        [SerializeField] private float jumpWaitTime;
         private float jumpWaitTimer;
        [SerializeField] private float jump;
        private float horizontal;

        private float vertical;
        public Collider2D playerCollider;

        [SerializeField] Transform groundCheckCollider;
        [SerializeField] LayerMask groundLayer;
        const float groundCheckRadius = 0.2f;
        [SerializeField] bool isGrounded = false;

        private void Awake()
        {
            Debug.Log("Player controller awake");            
            rb = gameObject.GetComponent<Rigidbody2D>();
            animator = GetComponent<Animator>();
        }

        public void PickUpKey() {
        Debug.Log("Player picked up the key");
        scoreController.IncrementScore(10);
        }

        public void KillPlayer()
        {
            Debug.Log("Player Killed");
            gameOverController.GameOver();
            this.enabled = false;
        }
                
        private void Update() {
            horizontal = Input.GetAxisRaw("Horizontal");
            vertical = Input.GetAxisRaw("Vertical");

            isGrounded = playerCollider.IsTouchingLayers(groundLayer);
            PlayerJumpMovement(vertical);
        }

        private void FixedUpdate()
        {
            //GroundCheck();            
            PlayerMoving(horizontal);
            
            PlayerCrouchMovement();
        }

        void PlayerMoving(float horizontal) 
        {
            animator.SetFloat("Speed", Mathf.Abs(horizontal));
            //Move character horizontally
            Vector3 position = transform.position;
            Vector3 scale = transform.localScale;

            // speed = distance / time;      time.deltaTime = 1 / Frames per second
            position.x = position.x + horizontal * speed * Time.deltaTime;
            transform.position = position;

            if (horizontal < 0)
            {
                scale.x = -1f * Mathf.Abs(scale.x);
            }
            else if (horizontal > 0)
            {
                scale.x = Mathf.Abs(scale.x);
            }
            transform.localScale = scale;
        }

        void PlayerJumpMovement(float vertical) 
        {
            if(isGrounded || jumpWaitTimer > 0f)
            {
                if (!(vertical < 0))
                {
                    animator.SetBool("Jump", false);
                }
                if (vertical > 0)
                {
                    animator.SetBool("Jump", true);
                    rb.AddForce(new Vector2(0f, jump), ForceMode2D.Force);
                }
            }

            //Timer
            if (isGrounded)
            {
                jumpWaitTimer = jumpWaitTime;
            }
            else
            {
                if (jumpWaitTimer > 0f)
                {
                    jumpWaitTimer -= Time.deltaTime;
                }
            }
        }

        void PlayerCrouchMovement() 
        {
        if(Input.GetKeyDown(KeyCode.RightControl)) 
        {
            animator.SetBool("Crouch", true);
        }
        else if(Input.GetKeyUp(KeyCode.RightControl)) 
        {
            animator.SetBool("Crouch", false);
        }
    }
        /*void GroundCheck()
        {
            isGrounded = false;
            Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheckCollider.position, groundCheckRadius, groundLayer);
            if (colliders.Length > 0)
            {
                isGrounded = true;
            }
        }*/

        private void OnCollisionEnter2D(Collision2D collision) 
        {
            if ((collision.gameObject.CompareTag("Death")) || collision.gameObject.GetComponent<PlayerController>() != null)
            {
                Debug.Log("Player Died");
                Destroy(gameObject);
                LevelManager.instance.Respawn();
            }
        }
    }
}