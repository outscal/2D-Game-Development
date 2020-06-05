using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed;
	public bool MoveRight;

    private void Update()
    {
		if(MoveRight)
		{
			transform.Translate(1 * Time.deltaTime * speed, 0, 0);
			transform.localScale = new Vector2 (1, 1);
		}else
		{
			transform.Translate(-1 * Time.deltaTime * speed, 0, 0);
			transform.localScale = new Vector2 (-1,  1);
		}
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.gameObject.CompareTag("Walls"))
		{
			if(MoveRight){
				MoveRight = false;
			}
			else{
				MoveRight = true;
			}
		}
	}
}
