using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Animator animator;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float jumpStrength;
    public static PlayerController instance;

    private void Awake()
    {
        instance = this;
        Debug.Log("Player controller awake");
    }
//    private void OnCollisionEnter2D(Collision2D collision) {
//        Debug.Log("Collision : " + collision.gameObject.name);
//    }

        private void Start() {
            rb = GetComponent<Rigidbody2D>();
            animator = GetComponent<Animator>();
        }

    private void Update() {
        float speed = Input.GetAxisRaw("Horizontal");
        float jump = Input.GetAxisRaw("Vertical");

        PlayerRunnig(speed);
        PlayerJumping(jump);
    }

    void PlayerRunnig(float speed) {
        animator.SetFloat("Speed", Mathf.Abs(speed));
        
        Vector3 scale = transform.localScale;
        
        if(speed < 0) {
            scale.x = -1f * Mathf.Abs(scale.x);
        } 
        else if(speed > 0) {
            scale.x = Mathf.Abs(scale.x);
        }
        transform.localScale = scale;
    }

    void PlayerJumping(float jump) {
        //animator.SetFloat("Jump", Mathf.Abs(jump));

        //Vector3 position = transform.position;
        
        if(jump > 0) {
            animator.SetBool("Jump", true);
            rb.AddForce(new Vector2(0f, jumpStrength), ForceMode2D.Impulse);
        }
        else {
            animator.SetBool("Jump",false);
        }
    }
}
