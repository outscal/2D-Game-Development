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

    [SerializeField] private float walkSpeed;
    private bool mustPatrol = true;
    public float distance;
    public Transform groundDetection;

    void Update()
    {
        transform.Translate(Vector2.right * walkSpeed * Time.deltaTime);

        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distance);
        if(groundInfo.collider == false)
        {
            if(mustPatrol == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                mustPatrol = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                mustPatrol = true;
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
