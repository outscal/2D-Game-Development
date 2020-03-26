using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public Animator animator;

	public float speed;
	public float jump;

	private Rigidbody2D rb2D;


	private void Awake()
	{
		Debug.Log("Player controller Awake");
		rb2D = gameObject.GetComponent<Rigidbody2D>();
	}

	/*private void OnCollisionEnter2D(Collision2D collision)
	{
		Debug.Log("Collision: "+collision.gameObject.name);
	}*/

	private void Update()
	{
		float horizontal = Input.GetAxisRaw("Horizontal");
		float vertical = Input.GetAxisRaw("Jump");

		MoveCharacter(horizontal, vertical);  //Move the character
		PlayerMovementAnimation(horizontal, vertical); //Play animations
	}
	
	//Movement of character from one place to another
	private void MoveCharacter(float horizontal, float vertical)
	{
		//Move Character horizontally
		Vector3 position = transform.position;
		position.x += horizontal * speed * Time.deltaTime;            //(Distance / seconds) * (1 / 30frames per sec)
		transform.position = position;

		//Move Character vertically
		if(vertical > 0){
			rb2D.AddForce(new Vector2(0f, jump), ForceMode2D.Force);
		}
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
	void OnCollisionEnter2D(Collision2D coll)
	{
		if(coll.gameObject.CompareTag ("Enemy"))
		{
			Debug.Log("over");
		}
	}
}