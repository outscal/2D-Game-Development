using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMovement : MonoBehaviour {

    public float speed;
    public float jumpSpeed;
    float horizontal, vertical;
    private bool facingRight = true;
    private Rigidbody2D rb;
    public Animator animator;

    // Start is called before the first frame update
    void Start () {
        rb = GetComponent<Rigidbody2D> ();
    }

    // Update is called once per frame
    void Update () {

        horizontal = Input.GetAxisRaw ("Horizontal") * speed;
        // vertical = Input.GetAxisRaw ("Vertical") * 500f;
        if (Input.GetMouseButtonDown (0)) {
            // jumpPlayer ();
            // rb.AddForce = Vector2.up * jumpSpeed;
            jumpPlayer ();
            Debug.Log ("jump " + rb.velocity);
        }
        animator.SetFloat ("speed", Mathf.Abs (horizontal));
    }

    void FixedUpdate () {
        movePlayer (horizontal, vertical);
        if (facingRight == true && horizontal < 0)
            Flip ();
        if (facingRight == false && horizontal > 0)
            Flip ();
    }

    public void movePlayer (float move, float move2) {
        rb.velocity = new Vector2 (move * Time.fixedDeltaTime, 0);
    }
    public void jumpPlayer () {
        rb.velocity = Vector2.up * jumpSpeed;
        Debug.Log ("jump " + rb.velocity);
    }

    public void Flip () {
        facingRight = !facingRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }

}