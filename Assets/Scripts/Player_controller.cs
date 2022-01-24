using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_controller : MonoBehaviour
{
    public Animator animator;

    public float speed;
    public float jump;
    
    private Rigidbody2D rb2d;
    private void Awake()
    {
        Debug.Log("Player controller awake");
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        SpriteRenderer sprite = gameObject.GetComponent<SpriteRenderer>();      
    }
    

    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float  vertical = Input.GetAxisRaw("Vertical");

        MoveCharacter(horizontal, vertical ); 

        PlayMovementAnimation(horizontal,vertical);


 
    }
    private void MoveCharacter(float horizontal, float vertical )
    {

        Vector3 position = transform.position;
        position.x += horizontal * speed * Time.deltaTime;
        transform.position = position;


        if (vertical > 0)
        {
           rb2d.AddForce(new Vector2(0f,jump),ForceMode2D.Force);
        }

    }


    private void PlayMovementAnimation(float horizontal , float vertical)
    {
        animator.SetFloat("Speed", Mathf.Abs(horizontal));


        Vector3 scale = transform.localScale;
        if (horizontal < 0)
        {
            scale.x = -1f * Mathf.Abs(scale.x);

        }
        else if (horizontal > 0)
        {
            scale.x = Mathf.Abs(scale.x);

        }
        transform.localScale = scale;

        // Input.GetKeyDown(KeyCode.Space);
        if ( vertical > 0)
        {
        animator.SetBool("Jump" , true );
        } else
        {
            animator.SetBool("Jump", false);
        }
    }
    // private bool IsGrounded(){
    //       float extraHeightText = .01f;
    //         RaycastHit2D RaycastHit = Physics2D.Raycast(boxCollider2d.bounds.center, Vector3.down, boxCollider2d.bounds.extents.y + extraHeightText);  
    //         Color rayColor; 
    //                if (raycastHit.collider !=null) {
    //                    rayColor = Color.green;

    //         }
    //         else {
    //             rayColor = Color.red;
    //         }
    //         Debug.DrawRay(boxCollider2d.bounds.center,Vector3.down * (boxCollider2d.bounds.extents.y + extraHeightText));
    //      return raycastHit.collider != null;0
    //     }

}
