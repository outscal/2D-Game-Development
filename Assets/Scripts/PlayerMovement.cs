using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour {

    public float speed;
    public float jumpSpeed;
    float moveInput;
    private bool facingRight = true;
    public Rigidbody2D rb;
    public Animator animator;

    private bool isGrounded;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask whatIsGround;
    public LayerMask enemy;
    public GameObject gameOverUI;

    void Start () {
        gameOverUI.SetActive (false);
    }

    void FixedUpdate () {
        moveInput = Input.GetAxisRaw ("Horizontal");

        MovePlayer (moveInput);
        if (facingRight == true && moveInput < 0)
            Flip ();
        if (facingRight == false && moveInput > 0)
            Flip ();
    }

    void Update () {

        isGrounded = Physics2D.OverlapCircle (feetPos.position, checkRadius, whatIsGround);

        if (isGrounded == true && Input.GetButtonDown ("Jump")) {
            rb.velocity = Vector2.up * jumpSpeed;
        }
        if (moveInput == 0) {
            animator.SetBool ("isRunning", false);
        } else {
            animator.SetBool ("isRunning", true);
        }
        // animator.SetFloat ("speed", Mathf.Abs (moveInput));
        animator.SetBool ("isGrounded", isGrounded);
    }

    private void OnCollisionEnter2D (Collision2D other) {
        if (other.collider.gameObject.layer == LayerMask.NameToLayer ("Water")) {
            gameOverUI.SetActive (true);
            Time.timeScale = 0;
        }
    }

    public void MovePlayer (float move) {
        if (Input.GetKey (KeyCode.LeftShift) && move != 0) {
            rb.velocity = new Vector2 (move * Time.fixedDeltaTime * speed * 2, rb.velocity.y);
            return;
        }
        rb.velocity = new Vector2 (move * Time.fixedDeltaTime * speed, rb.velocity.y);
    }

    public void Flip () {
        facingRight = !facingRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }

    public void RestartGame () {
        Time.timeScale = 1;
        SceneManager.LoadScene ("2dPlatformer");
    }

}