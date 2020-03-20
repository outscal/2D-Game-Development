using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Animator animator;
 

    private void Awake()
    {
        Debug.Log("Player controller awake.");
    }

    private void Update()
    {
        //Move to run transition animation.
        moveToRun();

        //Melle animation when pressing the mouse fire1 button.
        attackAnimation();

        //Crouch animation.
        crouchAnimation();

        jumpAnimation();



    }

    private void moveToRun()
    {
        float speed = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("speed", Mathf.Abs(speed));

        //Mathf.abs will always return positive value.

        Vector3 scale = transform.localScale;
        if (speed > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }
        else if (speed < 0)
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
