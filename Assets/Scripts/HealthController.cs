using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
	public PlayerController playerController;

	[SerializeField] Image lifeFill;

	float life = 1f; //life between 0.0 & 1.0  0 = dead

	void OnCollisionEnter2D(Collision2D other)
	{
		if(other.gameObject.GetComponent<EnemyController>() != null)
		{
			Debug.Log("Health is working");
			RemoveLife();
			if(life < 0.1f)
			{
				playerController.KillPlayer();
			}
		}
	}

	void RemoveLife()
	{
		if(life > 0)
		{
			life -= 0.2f;
			lifeFill.fillAmount = life;
		}
	}
}
