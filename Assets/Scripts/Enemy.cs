using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour 
{

    private bool facingRight = false;
    public float speed = -5;
    public float downDistance;
    public float upDistance;
    public Transform groundDetector;
    public Transform playerDetector;
    private Animator animator;
    private Rigidbody2D rb;

    public enum animState
    {
        walking=0,
        dead=1
    }
    void Start () 
    {
        animator = GetComponent<Animator>();
        rb =  GetComponent<Rigidbody2D>();
    }

    //private void FixedUpdate()
    //{
    //    rb.MovePosition ((Vector2)transform.position + new Vector2(speed*Time.deltaTime, transform.position.y));
    //}

    void Update () 
    {
        //transform.Translate(Vector2.right * speed * Time.deltaTime);
        rb.velocity = new Vector2(speed * Time.deltaTime, rb.velocity.y);
        RaycastHit2D groundInfo = Physics2D.Raycast (groundDetector.position, Vector2.down, downDistance);


        if (groundInfo.collider == false) 
        {
            if (facingRight == true)
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                speed = -speed;
                facingRight = false;
            } else 
            {
                transform.eulerAngles = new Vector3(0, 180, 0);
                speed = -speed;
                facingRight = true;
            }
        }
    }

    private void OnTriggerEnter2D (Collider2D other) 
    {
        if (other.gameObject.CompareTag ("feetpos"))
        {
            GetComponent<Collider2D>().enabled = false;
            animator.SetInteger("death", (int)animState.dead);
            StartCoroutine(destroyObject());
            //Destroy (gameObject);
        }
    }

    IEnumerator destroyObject()
    {
        yield return new WaitForSeconds(0.3f);
        Destroy(gameObject);
    }

}