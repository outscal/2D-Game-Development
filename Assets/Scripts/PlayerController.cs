using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace playerMovement 
{
    public class PlayerController : MonoBehaviour
    {
        //Animator animator;
        public ScoreController scoreController;
        public HealthController healthController;
        public GameOverController gameOverController;

        //[SerializeField] private Rigidbody2D rb;
        //[SerializeField] private float speed;
        //[SerializeField] private BoxCollider2D box_collider;
        //[SerializeField] private float jumpWaitTime;
        //[SerializeField] private float jump;
        //[SerializeField] int jumpcounter = 0;
       // private float dirX;
        //private Vector3 scale;
        //private float horizontal;

        //private float vertical;

        //[SerializeField] Transform groundCheckCollider;
        //[SerializeField] LayerMask groundLayer;
        //const float groundCheckRadius = 0.2f;
        //[SerializeField] bool isGrounded = false;
        //[SerializeField] float jumpPower = 300;
        //bool jump = false;
        //bool jumpFlag;

        //bool isJumping;
        //bool isGround;
        //bool crouch;

        public Animator animator;

        public float Speed;
        public float jump;

        private Rigidbody2D rb2d;
        private BoxCollider2D boxCollider;

        [SerializeField] private LayerMask platformLayerMask;

        private void Awake()
        {
            rb2d = gameObject.GetComponent<Rigidbody2D>();
            boxCollider = gameObject.GetComponent<BoxCollider2D>();
        }

        private void Update()
        {
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Jump");

            PlayerMovementAnimation(horizontal, vertical);
            MoveCharacter(horizontal, vertical);

            // play crouch animation
            if (Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.RightControl))
            {
                if (animator != null)
                {
                    animator.SetBool("Crouch", true);
                }
            }
            else
            {
                if (animator != null)
                {
                    animator.SetBool("Crouch", false);
                }
            }

        }

        private void PlayerMovementAnimation(float horizontal, float vertical)
        {
            if (animator != null)
            {
                // Setting float value of speed inside animator
                animator.SetFloat("Speed", Mathf.Abs(horizontal));

                // Setting value of 'jump' boolean
                if (vertical > 0 && IsGrounded())
                {
                    animator.SetBool("Jump", true);
                }
                else
                {
                    animator.SetBool("Jump", false);
                }
            }

            // Change the direction of player
            Vector3 scale = transform.localScale;

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

        private void MoveCharacter(float horizontal, float vertical)
        {
            // Horizontal character movement
            Vector3 position = transform.position;
            position.x += horizontal * Speed * Time.deltaTime;
            transform.position = position;

            // Vertical Character movement
            if (vertical > 0 && IsGrounded())
            {
                rb2d.AddForce(new Vector2(0f, jump), ForceMode2D.Force);
            }
        }

        private bool IsGrounded()
        {
            float extraHeight = 0.3f;

            RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0f, Vector2.down, extraHeight, platformLayerMask);
            return raycastHit.collider != null;
        }

        public void PickUpKey()
        {            
            Debug.Log("Player picked up the key");
            scoreController.IncrementScore(10);           
        }

        public void KillPlayer()
        {
            Debug.Log("Player Killed");
            gameOverController.GameOver();
            this.enabled = false;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if ((collision.gameObject.CompareTag("Death")) || collision.gameObject.GetComponent<PlayerController>() != null)
            {
                Debug.Log("Player Died");
                Destroy(gameObject);
                RespawnLevel.instance.Respawn();
            }
        }
    }
}