using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public ScoreController scoreController;
    public GameOverController gameOverController; 

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

    public void KillPlayer()
    {
        Debug.Log("player killed by enemy");
        //Destroy(gameObject);

        ReloadLevel();
        gameOverController.PlayerDied();
        this.enabled = false;
    }

    private void ReloadLevel()
    {
        Debug.Log("Reloading scene 0");
        SceneManager.LoadScene(0);
    }

    public void PickUpKey()
    {
        Debug.Log("player picked up the key");
          scoreController.IncreaseScore(10);
      //  scoreController.IncreaseScore(10);
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    Debug.Log("Collision: " + collision.gameObject.name);
    //}

    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Jump");


        MoveCharacter(horizontal , vertical);
        PlayerMovementAnimation(horizontal , vertical);


    }

    private void MoveCharacter(float horizontal , float vertical)
    {
        // move character horizontally
        Vector3 position = transform.position;
        //(Distance / Time) * (
        position.x += horizontal * speed * Time.deltaTime;
        transform.position = position;

        // move character vertically
        if(vertical > 0)
        {
            rb2d.AddForce(new Vector2(0f, jump), ForceMode2D.Impulse);

        }

    }

    private void PlayerMovementAnimation(float horizontal , float vertical)
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

        // Jump
        if (vertical > 0)
        {
            animator.SetBool("Jump", true);
        }
        else
        {
            animator.SetBool("Jump", false);
        }
    }
}
