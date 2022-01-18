using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_controller : MonoBehaviour
{
    public Animator animator;  
   private void Awake ()
    {
        Debug.Log("Player controller awake");

    }

    private void update ()
    {
        float speed = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("Speed", Mathf.Abs(speed));
        if (speed < 0)
        {
            Vector3 scale = transform.localScale;
            if (speed <0 ) { 
            scale.x = -1f * Mathf.Abs(scale.x);
        } else if (speed > 0)
        {
            scale.x = Mathf.Abs(scale.x);

        }
        transform.localScale = scale;


    }

    
}
