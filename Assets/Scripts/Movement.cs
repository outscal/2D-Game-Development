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
        float speed = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("speed",Mathf.Abs(speed));

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
}
