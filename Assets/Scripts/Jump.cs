using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    [Range(1, 10)]
    public float jumpVelocity;
    
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;

    private Rigidbody2D rb;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Jump"))
        {
            rb.velocity = Vector2.up * jumpVelocity;
        }

        //if(rb.velocity.y < 0)
        //{
         //   rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        //}
        //else if(rb.velocity.y > 0 && !Input.GetButton("Jump"))
          //  {
            //    rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
            //}
    }
}