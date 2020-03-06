using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotionHandler : MonoBehaviour
{
    private Animator playerAnimator;
    private Rigidbody2D rb;
    private bool isFacingRight = true;
    public float speed = 5.0f;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float move = Input.GetAxis(Tags.Horizontal);
        //float jump =Input.GetAxis(Tags.Jump);

        Movement(move);
    }

    void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector2 dimension = transform.localScale;
        transform.localScale = new Vector2(-1 * dimension.x, dimension.y);
    }

    void Movement(float move)
    {
        playerAnimator.SetFloat(Tags.HorizontalSpeed, Mathf.Abs(move));
        rb.velocity = new Vector2(move * speed, 0);
        print(rb.velocity.y);
        if (move < 0 & isFacingRight)
        {
            Flip();
        }
        else if (move > 0 & !isFacingRight)
        {
            Flip();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerAnimator.SetTrigger(Tags.Jump);
            rb.AddForce(new Vector2(0.0f, 150000.0f), ForceMode2D.Force);
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            playerAnimator.SetBool(Tags.Crouching, !playerAnimator.GetBool(Tags.Crouching));
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            playerAnimator.SetBool(Tags.Pushing, true);
        }

        if (Input.GetKeyUp(KeyCode.P))
        {
            playerAnimator.SetBool(Tags.Pushing, false);
        }
    }
}
