using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Player Actions")]
    public float walkSpeed;
    public float runSpeed;
    public float jumpForce;
    public bool isFacingRight = true;
    public LayerMask Ground;


    [Header("Player States")]
    bool isIdle = true, isWalking, isRunning, isGrounded, isJumping, isCrouched;

    [Header("Unity Essentails")]
    Rigidbody2D rb2d;
    Animator animator;
    float localScaleX;
    public Transform groundCheck;

    private void Start()
    {
        animator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {

        #region Walking and Idle
        float movement = Input.GetAxis("Horizontal");
        if (movement < 0 && !isJumping && !isCrouched)
        {
            isWalking = true;
            isIdle = false;
            animator.SetBool("isWalking", true);
            Debug.Log("Moveing Left");
            if (isRunning)
                rb2d.AddForce(new Vector2(-1, 0) * runSpeed);
            else
                rb2d.AddForce(new Vector2(-1, 0) * walkSpeed);
            if (isFacingRight) flip();

        }
        else if (movement > 0 && !isJumping && !isCrouched)
        {
            isWalking = true;
            isIdle = false;
            animator.SetBool("isWalking", true);
            Debug.Log("Moving Right");

            if (isRunning)
                rb2d.AddForce(new Vector2(1, 0) * runSpeed);
            else
                rb2d.AddForce(new Vector2(1, 0) * walkSpeed);

            if (!isFacingRight) flip();
        }
        else
        {
            if (!isIdle)
            {
                animator.SetBool("isWalking", false);
                isIdle = true;
                isWalking = false;
                isRunning = false;
                isJumping = false;
            }
        }
        #endregion

        #region  Running
        if (movement != 0 && Input.GetKey(KeyCode.LeftShift) && !isJumping)
        {
            if (!isRunning)
            {

                animator.SetBool("isRunning", true);
                isRunning = true;
            }
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            isRunning = false;
            animator.SetBool("isRunning", false);
        }

        #endregion

        #region  Jumping
        isGrounded = Physics2D.Raycast(groundCheck.position, Vector2.down, 0.1f, Ground);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded && !isJumping)
            {
                StartCoroutine(Jump());
            }
        }
        #endregion

        //crouch
        if (Input.GetKeyDown(KeyCode.C) && !isCrouched)
        {
            isCrouched = true;
            animator.SetBool("isCrouched", true);
        }
        else if (Input.GetKeyDown(KeyCode.C) && isCrouched)
        {
            isCrouched = false;
            animator.SetBool("isCrouched", false);
        }
    }

    IEnumerator Jump()
    {
        isJumping = true;
        animator.SetBool("isJumping", true);
        rb2d.AddForce(new Vector2(0, 1) * jumpForce);
        //yield return new WaitUntil(() => isGrounded);
        yield return new WaitForSeconds(1f);
        isJumping = false;
        animator.SetBool("isJumping", false);

    }

    void flip()
    {
        isFacingRight = !isFacingRight;
        localScaleX = transform.localScale.x;
        localScaleX *= -1;
        transform.localScale = new Vector2(localScaleX, transform.localScale.y);
    }
}
