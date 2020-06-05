using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
	public ScoreController scoreController;
	public GameOver gameover;

	public Animator animator;

	public float speed;
	public float jumpForce;

	bool jumped = false;

	private Rigidbody2D rb2D;

	private void Awake()
	{
		Debug.Log("Player controller Awake");
		rb2D = gameObject.GetComponent<Rigidbody2D>();
	}

	public void KillPlayer()
	{
		//Destroy(gameObject);
		gameover.PlayerDied();
		Debug.Log("Player killed");
		this.enabled = false;
	}

	public void PickupKey()
	{
		Debug.Log("Picked up the key");
		scoreController.IncreaseScore(10);
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		Debug.Log("Collision: "+collision.gameObject.name);
		if (collision.gameObject.CompareTag("Ground"))
		{
			jumped = true;
			Debug.Log("Ground is: " + collision.gameObject.tag);
		}
	}

	private void Update()
	{
		float horizontal = Input.GetAxisRaw("Horizontal");
		float vertical = Input.GetAxisRaw("Jump");

		MoveCharacter(horizontal, vertical);  //Move the character
		PlayerMovementAnimation(horizontal, vertical); //Play animations
	}
	
	private void MoveCharacter(float horizontal, float vertical)
	{
		//Move Character horizontally
		Vector3 position = transform.position;
		position.x += horizontal * speed * Time.deltaTime;            //(Distance / seconds) * (1 / 30frames per sec)
		transform.position = position;

		//Move Character vertically
		if (vertical > 0 && jumped)
		{
			rb2D.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Force);
		}
		else jumped = false;
	}
	
	//Player animations
	private void PlayerMovementAnimation(float horizontal, float vertical)
	{
		animator.SetFloat("Speed", Mathf.Abs(horizontal));

		Vector3 scale = transform.localScale;
		if(horizontal < 0){
			scale.x = -1f * Mathf.Abs(scale.x);
		} else if(horizontal > 0){
			scale.x = Mathf.Abs(scale.x);
		}
		transform.localScale = scale;
		
		//Jump
		if(vertical > 0){
			animator.SetBool("Jump", true);
		}else{
			animator.SetBool("Jump", false);
		}	
	}
}