using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Animator playerAnimator;
    [SerializeField] BoxCollider2D fullCollider;
    [SerializeField] Rigidbody2D rb;

    [SerializeField] float playerJump;
   


    void Start()
    {
        playerAnimator = GetComponent<Animator>();
        fullCollider = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
       
    }

    
    void Update()
    {

        RunPlayer();
        PlayerCrouch();
        PlayerJump();

    }

    private void PlayerJump()
    {
        if(Input.GetKeyDown(KeyCode.Space))
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
        float playerSpeed = Input.GetAxisRaw("Horizontal");
        Vector3 scale = transform.localScale;
        playerAnimator.SetFloat("speed", Mathf.Abs(playerSpeed));
        playerAnimator.SetBool("jump", false);

        
        
        if (playerSpeed < 0)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
        if (playerSpeed > 0)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
       
    }
}
