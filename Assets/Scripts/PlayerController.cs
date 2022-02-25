using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Animator animator;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed;
    //[SerializeField] private float jump;

    private void Awake()
    {
        Debug.Log("Player controller awake");
        rb = gameObject.GetComponent<Rigidbody2D>();
        SpriteRenderer sprite = gameObject.GetComponent<SpriteRenderer>();
    }

        private void Start() {
            rb = GetComponent<Rigidbody2D>();
            animator = GetComponent<Animator>();
        }

    private void Update() {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        PlayerMoving(horizontal, vertical);
        PlayerMovememtAnimation(horizontal, vertical);
    }

    void PlayerMoving(float horizontal, float vertical) {
        //Move character horizontally
        Vector3 position = transform.position;

        // speed = distance / time;      timr.deltaTime = 1 / Frames per second
        position.x = position.x + horizontal * speed * Time.deltaTime;
        transform.position = position; 

        //Move character vertically
    //    if(vertical > 0) {
    //         animator.SetBool("Jump", true);
    //         rb.AddForce(new Vector2(0f, jump), ForceMode2D.Force);
    //     }
    //     else {
    //         animator.SetBool("Jump",false);
    //     }

    }

    void PlayerMovememtAnimation(float horizontal, float vertical) {
        animator.SetFloat("Speed", Mathf.Abs(horizontal));
        
        Vector3 scale = transform.localScale;
        
        if(horizontal < 0) {
            scale.x = -1f * Mathf.Abs(scale.x);
        } 
        else if(horizontal > 0) {
            scale.x = Mathf.Abs(scale.x);
        }
        transform.localScale = scale;

        //Jump

        // if(vertical > 0) {
        //     animator.SetBool("Jump", true);
        // }
        // else {
        //     animator.SetBool("Jump", false);
        // }
    }

}
