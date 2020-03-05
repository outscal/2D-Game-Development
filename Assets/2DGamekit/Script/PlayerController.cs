

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator playerAnimator;
    private Rigidbody2D rb;
    private bool isFacingRight = true;
    private bool isFirstTime = true;



    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float move = Input.GetAxis(Tags.Horizontal);
        float jump = Input.GetAxis(Tags.Vertical);
        float jumpScaler = Mathf.Lerp(17.5f, -17.5f, jump);

        playerAnimator.SetFloat(Tags.HorizontalSpeed, Mathf.Abs(move));
        if (playerAnimator.GetBool(Tags.Grounded))
        {
            if (move < 0 & isFacingRight)
            {
                Flip();
            }
            else if (move > 0 & !isFacingRight)
            {
                Flip();
            }

            if(jump > 0 & isFirstTime)
            {
                playerAnimator.SetBool(Tags.Grounded, false);
                isFirstTime = false;
            }

            if (Input.GetKeyDown(KeyCode.C))
            {
                playerAnimator.SetBool(Tags.Crouching, !playerAnimator.GetBool(Tags.Crouching));
                playerAnimator.SetBool(Tags.Grounded, true);
            }

            if (Input.GetKeyDown(KeyCode.P))
            {
                playerAnimator.SetBool(Tags.Pushing, true);
            }
            if (Input.GetKeyUp(KeyCode.P))
            {
                playerAnimator.SetBool(Tags.Pushing, false);
            }
            if (Input.GetMouseButtonDown(0))
            {
                playerAnimator.SetTrigger(Tags.MeleeAttack);
            }
            if (Input.GetMouseButtonDown(1))
            {
                playerAnimator.SetBool(Tags.HoldingGun,!playerAnimator.GetBool(Tags.HoldingGun));
            }

            if (Input.GetKeyDown(KeyCode.H))
            {
                playerAnimator.SetBool(Tags.Grounded, false);
                playerAnimator.SetTrigger(Tags.Hurt);
            }
            if (Input.GetKeyUp(KeyCode.H))
            {
                playerAnimator.SetBool(Tags.Grounded, true);
            }

        }
        Jumping(jumpScaler);
    }

    void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector2 dimension = transform.localScale;
        transform.localScale = new Vector2(-1*dimension.x ,dimension.y);
    }

    void Jumping(float frameIndex)
    {
        playerAnimator.SetFloat(Tags.VerticalSpeed, frameIndex);
        if(Input.GetKeyDown(KeyCode.W) | Input.GetKeyDown(KeyCode.UpArrow))
        {
            isFirstTime = true;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            playerAnimator.SetBool(Tags.Grounded, true);
            print("inTheGround");
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            playerAnimator.SetBool(Tags.Grounded, false);
            print("inTheGround");
        }
    }
}
