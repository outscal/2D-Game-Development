using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Animator playerAnimator;
    [SerializeField] BoxCollider2D fullCollider;
    public Rigidbody2D rb;
    public float speed;
    [SerializeField] float playerJump;

    [SerializeField] LayerMask groundlayer;
    [SerializeField] Transform groundcheckTansform;
    public float circleRadius;
    [SerializeField] bool isGrounded;
   


    void Start()
    {
        playerAnimator = GetComponent<Animator>();
        fullCollider = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();       
    }

    
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundcheckTansform.position, circleRadius, groundlayer);
        RunPlayer();
        PlayerCrouch();
        PlayerJump();
    }

    private void PlayerJump()
    {
        if(Input.GetKeyDown(KeyCode.Space)&&isGrounded)
        {
            playerAnimator.SetTrigger("jump");
            rb.velocity = new Vector2(0, playerJump);
        }        
    }

    private void PlayerCrouch()
    {

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            fullCollider.enabled = false;           
            playerAnimator.SetBool("crouch", true);           
        }
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            fullCollider.enabled = true;
            playerAnimator.SetBool("crouch", false);
        }

    }

    private void RunPlayer()
    {
        float playerXmovement = Input.GetAxisRaw("Horizontal");
        Vector2 playerPos = transform.position;
        playerPos.x = playerPos.x + playerXmovement * speed * Time.deltaTime;
        transform.position = playerPos;
        Vector3 scale = transform.localScale;
        playerAnimator.SetFloat("speed", Mathf.Abs(playerXmovement));
        playerAnimator.SetBool("jump", false);

        
        
        if (playerXmovement < 0)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        } 
        if (playerXmovement > 0)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
       
    }
}
