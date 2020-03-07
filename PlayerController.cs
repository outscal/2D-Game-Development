using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    [Header("Player Actions")]
    public float walkSpeed;
    public float runSpeed;
    public float jumpForce;
    public bool isFacingRight = true;
    float movement;
    public LayerMask Ground;
    [Header("Player States")]
    [SerializeField] bool isGrounded;
    public TextMeshProUGUI text;
    int waterCount = 0;
    public GameObject LevelCompleteUI;
    public GameObject RestartButton;
    public GameObject GameOverImage;
    public enum AnimState
    {
        Idle, Walking, Running, Jumping, Crouched
    }

    public AnimState state = AnimState.Idle;

    [Header("Unity Essentails")]
    Rigidbody2D rb2d;
    Animator animator;
    float localScaleX;
    public Transform groundCheck;

    private void Start()
    {
        animator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        isGrounded = true;
        state = AnimState.Idle;
        text.text = "Water:" + waterCount.ToString();
    }
    void Update()
    {

        movement = Input.GetAxis("Horizontal");
        if ((isFacingRight && movement < 0) || (!isFacingRight && movement > 0)) flip();

        if (state != AnimState.Jumping)
        {
            #region  Running
            if (movement != 0 && Input.GetKey(KeyCode.LeftShift))
            {
                if (state != AnimState.Running && state != AnimState.Crouched)
                {

                    animator.SetBool("isRunning", true);
                    state = AnimState.Running;
                }
            }
            else if (Input.GetKeyUp(KeyCode.LeftShift) || movement == 0)
            {

                animator.SetBool("isRunning", false);
                if (state != AnimState.Walking && movement != 0 && state != AnimState.Crouched)
                    state = AnimState.Walking;
            }
            #endregion

            #region  Walking 

            if (movement != 0 && state != AnimState.Running)
            {
                animator.SetBool("isWalking", true);
                state = AnimState.Walking;
            }
            else if (movement == 0)
            {
                animator.SetBool("isWalking", false);
                state = AnimState.Idle;
            }
            #endregion

            #region  Jumping
            if (Input.GetKeyDown(KeyCode.Space) && state != AnimState.Crouched)
            {
                if (isGrounded)
                {
                    StartCoroutine(Jump());
                }
            }

            #endregion

            //crouch
            if (Input.GetKeyDown(KeyCode.C) && state != AnimState.Crouched)
            {
                state = AnimState.Crouched;
                animator.SetBool("isCrouched", true);
            }
            else if (Input.GetKeyDown(KeyCode.C) && state == AnimState.Crouched)
            {
                state = AnimState.Idle;
                animator.SetBool("isCrouched", false);
            }
        }
    }
    private void FixedUpdate()
    {
        #region Walking and Idle

        // isGrounded = Physics2D.Raycast(groundCheck.position, Vector2.down, 0.1f, Ground);

        if (state != AnimState.Crouched)
            if (state == AnimState.Walking || state == AnimState.Jumping)
                rb2d.velocity = new Vector2(movement * walkSpeed, rb2d.velocity.y);
            else if (state == AnimState.Running || state == AnimState.Jumping)
                rb2d.velocity = new Vector2(movement * runSpeed, rb2d.velocity.y);

        #endregion
    }
    IEnumerator Jump()
    {
        state = AnimState.Jumping;
        isGrounded = false;
        animator.SetTrigger("Jump");
        rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce);
        //yield return new WaitUntil(() => isGrounded);
        yield return new WaitForSeconds(1f);
        isGrounded = true;
        state = AnimState.Idle;
    }
    void flip()
    {
        isFacingRight = !isFacingRight;
        localScaleX = transform.localScale.x;
        localScaleX *= -1;
        transform.localScale = new Vector2(localScaleX, transform.localScale.y);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Water"))
        {
            waterCount++;
            text.text = "Water:" + waterCount.ToString();
            Destroy(other.gameObject);
        }

        if (other.CompareTag("Finish"))
        {
            if (waterCount == 5)
            {
                LevelCompleteUI.SetActive(true);
                Time.timeScale = 0;
                RestartButton.SetActive(true);

            }
        }

        if (other.CompareTag("Enemy"))
        {
            Time.timeScale = 0;
            RestartButton.SetActive(true);
            GameOverImage.SetActive(true);
        }
    }
}
