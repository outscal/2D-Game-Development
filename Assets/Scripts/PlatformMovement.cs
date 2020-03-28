using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{

    private bool facingRight = false;
    public float speed = -5;
    public float downDistance;
    //public float upDistance;
    public Transform rightDetector;
    public Transform leftDetector;

    private void Update()
    {
        Move();

    }

    private void Move()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        RaycastHit2D rightGround = Physics2D.Raycast(rightDetector.position, Vector2.down, downDistance);
        RaycastHit2D leftGround = Physics2D.Raycast(leftDetector.position, Vector2.down, downDistance);

        if (rightGround.collider == true)
        {
            if (facingRight == true)
            {
                speed = -speed;
                facingRight = false;
            }
            
        }  if (leftGround.collider == true)
        {
            if (facingRight == false)
            {
                speed = -speed;
                facingRight = true;
            }
           
        }
    }

   
}
