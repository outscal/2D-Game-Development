using System.Collections;
using UnityEngine;
using playerMovement;

/// <summary>
/// Player Death animation applied when the player touches the enemy.
/// Added enemy patrol
/// </summary>
public class EnemyController : MonoBehaviour
{
    Animator animator;
    public PlayerController playerController;
    public HealthController healthController;

    public float walkSpeed;
    public float distance;
    public bool moveRight = true;
    public Transform groundDetectionPoint;


    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {

        }
    }*/
    
    private void Update()
    {
        transform.Translate(Vector2.right * walkSpeed * Time.deltaTime);

        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetectionPoint.position, Vector2.down, distance);

        if (!groundInfo.collider)
        {
            if (moveRight)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                moveRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                moveRight = true;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            animator = collision.gameObject.GetComponent<Animator>();

            if (playerController != null)
            {
                healthController.LoseLife();
                // playerController.PlayerHit();
            }
            if (healthController.livesRemaining == 0)
            {
                StartCoroutine(PlayDeathCoroutine());
            }
        }
    }
    IEnumerator PlayDeathCoroutine()
    {
        animator.Play("Player_Death");
        yield return new WaitForSeconds(0.60f);
        playerController.KillPlayer();
    }
}
