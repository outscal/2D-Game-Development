using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotionHandler : MonoBehaviour
{
    private Animator playerAnimator;
    private Rigidbody2D rb;
    private bool isFacingRight = true;
    private float speed = 5.0f;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float move = Input.GetAxis(Tags.Horizontal);
        //float jump =Input.GetAxis(Tags.Jump);

        playerAnimator.SetFloat(Tags.HorizontalSpeed, Mathf.Abs(move));
        rb.velocity = new Vector2(move * speed, rb.velocity.y);
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

    void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector2 dimension = transform.localScale;
        transform.localScale = new Vector2(-1 * dimension.x, dimension.y);
    }
}
