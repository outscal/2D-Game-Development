using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public Animator animator;

	/*private void Awake()
	{
		Debug.Log("Player controller Awake");
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		Debug.Log("Collision: "+collision.gameObject.name);
	}*/

	private void Update()
	{
		float speed = Input.GetAxisRaw("Horizontal");

		animator.SetFloat("Speed", Mathf.Abs(speed));

		Vector3 scale = transform.localScale;
		if(speed < 0){
			scale.x = -1f * Mathf.Abs(scale.x);
		} else if(speed > 0){
			scale.x = Mathf.Abs(scale.x);
		}
		transform.localScale = scale;

		if(Input.GetKeyDown(KeyCode.Space)){
			animator.SetBool("Jump", true);
		}else{
			animator.SetBool("Jump", false);
		}

		if(Input.GetKeyDown(KeyCode.C)){    // I made a new Input button in input manager;
			animator.SetBool("Crouch", true);
		}else{
			animator.SetBool("Crouch", false);
		}

		if(Input.GetKeyDown(KeyCode.LeftShift)){
			animator.SetBool("Run", true);
		}else{
			animator.SetBool("Run", false);
		}
	}
}
