using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public ScoreController scoreController;

    public Animator animator;
    public Rigidbody2D rigidbody2D;
    public SpriteRenderer sprite;
    public BoxCollider2D boxCollider2D;

    public GameObject gameWonPanel;
	public GameObject gameLostPanel;

    public float jump;
    public bool isGrounded;
    public float speed;
    public Vector3 scale;
    public  Vector2 coliderSize, offsetSize;


    void Awake()
    {
        rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
        boxCollider2D = gameObject.GetComponent<BoxCollider2D>();
        sprite = gameObject.GetComponent<SpriteRenderer>();
    }
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Game Started");
        speed = 5f;
        jump = 1.7f;
         coliderSize = boxCollider2D.size;
        offsetSize = boxCollider2D.offset;
    }

    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        playerMovement(horizontal, vertical);
        MoveCharecter(horizontal, vertical);
        PLayerCrouch();
    }


    public void PickUpKey()
    {
        Debug.Log("Player Picked up the key");
        scoreController.IncreaseScore(10);
    
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
        // if(isGrounded && vertical > 0)
        if(vertical > 0)

        {
            rigidbody2D.AddForce(new Vector2(0f, jump), ForceMode2D.Impulse );
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
    }

    private void PLayerCrouch()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            animator.SetBool("Crouch", true);          
            boxCollider2D.size = new Vector2(1f, 1.303408f);
            boxCollider2D.offset = new Vector2(-0.01289269f, 0.5362488f);

        }else if (Input.GetKeyUp(KeyCode.LeftControl))
        {
             boxCollider2D.size = coliderSize;
             boxCollider2D.offset = offsetSize;
            
            animator.SetBool("Crouch", false);
        }     
    }

    void OnCollisionEnter2D(Collision2D col)
     {
		// Debug.Log ("I am at : "+ col.gameObject.name);
        
        if(col.gameObject.name == "Door")
        {
            gameWonPanel.SetActive (true);
            animator.enabled = false;
        }

         if(col.gameObject.name == "GroundTileMap")
        {
            isGrounded = true;
           //  Debug.Log("Is Grounded :" + isGrounded);

        }



     }

    public void RestartGame()
	{
		gameWonPanel.SetActive (false);
		SceneManager.LoadScene (6);
	}

    void OnCollisionExit2D(Collision2D collision)
    {
  
     if(collision.gameObject.name == "GroundTileMap")
        {
        isGrounded = false;
        }
        // Debug.Log("Is Grounded :" + isGrounded);

    }


}
