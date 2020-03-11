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
    public GameObject RestartButton;
    public GameObject GameOverImage;
    public enum AnimState
    {
        Idle, WalkingAnim, Running, JumpingAnim, Crouched
    }
    public AnimState state = AnimState.Idle;


    [Header("Unity Essentails")]
    Rigidbody2D rb2d;
    Animator animator;
    float localScaleX;
    public Transform groundCheck;
    public static PlayerController instance;
    [Header("GamePlay")]
    public bool gamePaused;

    private void Awake()
    {
        if (instance != null)
            Destroy(gameObject);
        else
            instance = this;
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        isGrounded = true;
        state = AnimState.Idle;
        // text.text = "Water:" + w aterCount.ToString();
    }
    void Update()
    {

        if (!gamePaused)
            movement = Input.GetAxis("Horizontal");

        if (shouldFlipCharacter())
            flip();


        if (state != AnimState.JumpingAnim)
        {
            RunningAnim();

            WalkingAnim();

            JumpingAnim();

            CrouchingAnim();
        }
    }

    private void CrouchingAnim()
    {
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

    private void JumpingAnim()
    {
        if (Input.GetKeyDown(KeyCode.Space) && state != AnimState.Crouched)
        {
            if (isGrounded)
            {
                StartCoroutine(Jump());
            }
        }
    }

    private void WalkingAnim()
    {
        if (movement != 0 && state != AnimState.Running)
        {
            animator.SetBool("isWalkingAnim", true);
            state = AnimState.WalkingAnim;
        }
        else if (movement == 0)
        {
            animator.SetBool("isWalkingAnim", false);
            state = AnimState.Idle;
        }
    }

    private bool shouldFlipCharacter()
    {
        return (isFacingRight && movement < 0) || (!isFacingRight && movement > 0);
    }

    private void RunningAnim()
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
            if (state != AnimState.WalkingAnim && movement != 0 && state != AnimState.Crouched)
                state = AnimState.WalkingAnim;
        }
        #endregion
    }

    private void FixedUpdate()
    {
        #region WalkingAnim and Idle

        isGrounded = Physics2D.Raycast(groundCheck.position, Vector2.down, 0.1f, Ground);

        if (state != AnimState.Crouched)
            if (state == AnimState.WalkingAnim || state == AnimState.JumpingAnim)
                rb2d.velocity = new Vector2(movement * walkSpeed, rb2d.velocity.y);
            else if (state == AnimState.Running || state == AnimState.JumpingAnim)
                rb2d.velocity = new Vector2(movement * runSpeed, rb2d.velocity.y);

        #endregion
    }
    IEnumerator Jump()
    {
        state = AnimState.JumpingAnim;
        isGrounded = false;
        animator.SetTrigger("Jump");
        rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce);
        yield return new WaitUntil(() => isGrounded);
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
        if (other.CompareTag("Enemy"))
        {
            RestartButton.SetActive(true);
            GameOverImage.SetActive(true);
        }
    }
}
