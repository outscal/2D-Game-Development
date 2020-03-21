using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Animator animator;

    public float speed;

    private void Awake()
    {
        Debug.Log("Player controller awake.");
    }

    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");

        characterMovement(horizontal);

        //Move to run transition animation.
        moveToRun(horizontal);

        //Melle animation when pressing the mouse fire1 button.
        attackAnimation();

        //Crouch animation.
        crouchAnimation();

        //Jump animation.
        jumpAnimation();



    }

    private void characterMovement(float horizontal)
    {
        Vector3 position = transform.position;
        position.x = position.x + horizontal * speed * Time.deltaTime;
        transform.position = position;
    }



    private void moveToRun(float horizontal)
    {
        animator.SetFloat("speed", Mathf.Abs(horizontal));

        //Mathf.abs will always return positive value.

        Vector3 scale = transform.localScale;
        if (horizontal > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }
        else if (horizontal < 0)
        {
            scale.x = -1f * Mathf.Abs(scale.x);

        }
        transform.localScale = scale;
    }

    private void attackAnimation()
    {
        bool attack = Input.GetButton("Fire1");
        animator.SetBool("attack", attack);


    }

    private void crouchAnimation()
    {
        bool crouch = Input.GetKey(KeyCode.C);
        animator.SetBool("crouch", crouch);
    }

    private void jumpAnimation()
    {
        bool Jump = Input.GetKey(KeyCode.Space);
        animator.SetBool("Jump", Jump);
    }

}
