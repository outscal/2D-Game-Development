using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using playerMovement;

public class CrouchMovement : MonoBehaviour
{
    Animator animator;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float crouch;
    [SerializeField] private BoxCollider2D b_idle;
    [SerializeField] private float jump;
    
    private void Awake() {
        SpriteRenderer sprite = gameObject.GetComponent<SpriteRenderer>();
    }

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        }

    private void Update() {
       float vertical = Input.GetAxisRaw("Vertical") ;
       PlayerCrouchMovement();
       PlayerJumpMovement(vertical);
    }

    void PlayerCrouchMovement() {
        if(Input.GetKeyDown(KeyCode.RightControl)) {
            animator.SetBool("Crouch", true);
            //rb.AddForce(new Vector2(0f, crouch), ForceMode2D.Force);
        }
        else if(Input.GetKeyUp(KeyCode.RightControl)) {
            animator.SetBool("Crouch", false);
        }
    }

    void PlayerJumpMovement(float vertical) {
        //Jump

        if(vertical > 0) {
            animator.SetBool("Jump", true);
            rb.AddForce(new Vector2(0f, jump), ForceMode2D.Force);
        }
        else {
            animator.SetBool("Jump", false);
        }
    }
}
