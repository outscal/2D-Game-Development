using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_controller : MonoBehaviour
{
    public Animator animator;

    public float speed;
    private Rigidbody2D rb2D;
    private void Awake()
    {
        Debug.Log("Player controller awake");
        rb2D = gameObject.GetComponent<Rigidbody2D>();

    }
    

    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");

        MoveCharacter(horizontal);

        PlayMovementAnimation(horizontal);



    }
    private void MoveCharacter(float horizontal)
    {

        Vector3 position = transform.position;
        position.x += horizontal * speed * Time.deltaTime;
        transform.position = position;

    }


    private void PlayMovementAnimation(float horizontal)
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

        Input.GetAxisRaw("Vertical");
        Input.GetKeyDown(KeyCode.Space);
    }
}
