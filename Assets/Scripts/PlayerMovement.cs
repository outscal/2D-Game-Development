using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour 
{

    public float speed;
    public float jumpSpeed;
    public float killJumpSpeed;
    float moveInput;
    private bool facingRight = true;
    public Rigidbody2D rb;
    public Animator animator;

    private bool isGrounded;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask whatIsGround;
    public LayerMask enemy;
    public GameObject gameOverUI;
    private Vector3 resetPos;

    public HealthManager healthManager;
    public Renderer rend;
    public AudioClip walkingClip;
    //public Key[] keys;
    //private int collectedKeys = 0;

    void Start () 
    {
        //collectedKeys = 0;
        gameOverUI.SetActive (false);
        resetPos = transform.position;
    }

    void FixedUpdate ()
    {
        moveInput = Input.GetAxisRaw ("Horizontal");

        MovePlayer (moveInput);
        if (facingRight == true && moveInput < 0)
            Flip ();
        if (facingRight == false && moveInput > 0)
            Flip ();
    }

    void Update () 
    {

        isGrounded = Physics2D.OverlapCircle (feetPos.position, checkRadius, whatIsGround);

        animator.SetBool("isGrounded", isGrounded);
        if (isGrounded == true && Input.GetButtonDown ("Jump")) 
        {
            JumpPlayer();
        }
        if (moveInput == 0) 
        {
            animator.SetBool ("isRunning", false);
        } else 
        {
            animator.SetBool ("isRunning", true);
        }
        // animator.SetFloat ("speed", Mathf.Abs (moveInput));
    }

    private void OnCollisionEnter2D (Collision2D other)
    {
        if (other.collider.gameObject.layer == LayerMask.NameToLayer ("Water")) 
        {
            CheckHealth();
        }
        if (other.gameObject.CompareTag ("Enemy")) 
        {
            CheckHealth();
        }
    }


    public void CheckHealth()
    {
        if (GameData.HEALTHCOUNT > GameData.minHealthCount)
        {
            healthManager.DecreaseHealth(GameData.healthValue);
            SoundManager.instance.playPlayerSound(Sfx.PlayerSfx.Death, false);
            StartCoroutine(RegeneratePlayer());
        }
        else
        {   
            SoundManager.instance.playGameSound(Sfx.GameSfx.GameOver, true);
            GameOver();
            Debug.Log("player destroyed");
            healthManager.DecreaseHealth(GameData.healthValue);
            Destroy(gameObject);
        }
    }

    IEnumerator RegeneratePlayer()
    {   
        SoundManager.instance.playPlayerSound(Sfx.PlayerSfx.Death,false);
        rend.enabled = false;
        yield return new WaitForSeconds(0.2f);
        resetPlayerPosition();
        rend.enabled = true;
    }
    public void resetPlayerPosition()
    {
        transform.position = resetPos;
    }

   private void GameOver()
    {
        LevelController.instance.SetGameoverUI();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy")){
            rb.velocity = Vector2.up * killJumpSpeed;
            //Destroy(collision.gameObject);
        }
    }
    
    
    public void JumpPlayer()
    {
        animator.SetBool("isGrounded", false);
        rb.velocity = Vector2.up * jumpSpeed;
        animator.SetTrigger("jump");
    }

    public void MovePlayer (float move) 
    {
        if (Input.GetKey (KeyCode.LeftShift) && move != 0) {
            rb.velocity = new Vector2 (move * Time.fixedDeltaTime * speed * 2, rb.velocity.y);
            return;
        }
        rb.velocity = new Vector2 (move * Time.fixedDeltaTime * speed, rb.velocity.y);
    }

    public void Flip ()
    {
        facingRight = !facingRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }

    public void PlayFootstep()
    {
        SoundManager.instance.playPlayerSound(Sfx.PlayerSfx.Walk, false);
    }

}