using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Animator animator;
    public float speed;
    public Vector3 scale;
    public Rigidbody2D rigidbody2D;
    public SpriteRenderer sprite;
    public float jump;
    public BoxCollider2D boxCollider2D;
    public  Vector2 coliderSize, offsetSize;
    public bool isGrounded = true;


    void Awake()
    {
        rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
        boxCollider2D = gameObject.GetComponent<BoxCollider2D>();
        sprite = gameObject.GetComponent<SpriteRenderer>();
        coliderSize = boxCollider2D.size;
        offsetSize = boxCollider2D.offset;
        Debug.Log(boxCollider2D);
        
    }
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start Function");
        speed = 5f;
        jump = 0.6f;
    }

    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        playerMovement(horizontal, vertical);
        MoveCharecter(horizontal, vertical);
        PLayerCrouch();
    }

    private void playerMovement(float horizontal, float vertical)
    {

         animator.SetFloat("speed", Mathf.Abs(horizontal));
         scale = transform.localScale;

        if(horizontal < 0) {
            scale.x = -1f * Mathf.Abs(scale.x);
        }
        else if(horizontal>0) {
            scale.x = Mathf.Abs(scale.x);
        }
       
        transform.localScale = scale;

        // Jump
        if(vertical > 0)
        {
            animator.SetBool("Jump", true);
        }
        else
        {
            animator.SetBool("Jump", false);
        }

    }

      private void MoveCharecter(float horizontal, float vertical)
    {

        Vector3 position = transform.position;
        position.x = position.x + horizontal * speed * Time.deltaTime;
        transform.position = position;

        // move character vertically

        if(vertical > 0)
        {
            rigidbody2D.AddForce(new Vector2(0f, jump), ForceMode2D.Impulse );
        }  

    }

    private void PLayerCrouch()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            animator.SetBool("Crouch", true);          
            boxCollider2D.size = new Vector2(1f, 1.303408f);
            boxCollider2D.offset = new Vector2(-0.01289269f, 0.6362488f);

            Debug.Log( boxCollider2D.size);
        }else if (Input.GetKeyUp(KeyCode.LeftControl))
        {
             boxCollider2D.size = coliderSize;
             boxCollider2D.offset = offsetSize;
            
            animator.SetBool("Crouch", false);
        }     
    }
}
