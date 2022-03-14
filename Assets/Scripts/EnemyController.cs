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
    [HideInInspector] public bool mustPatrol;
    private bool mustFlip;
    //public bool mustPatrol = true;
    public float distance;
    public Transform groundDetectionPoint;
    public Rigidbody2D rb;
    //public LayerMask groundLayer;
    public Collider2D bodyCollider;

    void Start()
    {
        mustPatrol = true;
    }
    void Update()
    {
        if(mustPatrol == true)
        {
            Patrol();
        }

        /*transform.Translate(Vector2.right * walkSpeed * Time.deltaTime);

        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetectionPoint.position, Vector2.down, distance);

        if (groundInfo.collider == false)
        {
            if (mustPatrol == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                mustPatrol = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                mustPatrol = true;
            }
        }*/
    }

    private void FixedUpdate()
    {
        if (mustPatrol == true)
        {
            RaycastHit2D groundInfo = Physics2D.Raycast(groundDetectionPoint.position, Vector2.down, distance);
            //mustFlip = !Physics2D.OverlapCircle(groundDetectionPoint.position, 0.1f, groundLayer);

            if (groundInfo.collider == false)
            {
                Flip();
                /*if (!groundInfo.collider.gameObject.CompareTag("Player"))
                {
                    Flip();
                }*/
                   
            }          
        }
    }

    void Patrol()
    {
        if (mustFlip == true)// || bodyCollider.IsTouchingLayers(groundLayer))
        {
            Flip();
        }
        rb.velocity = new Vector2(walkSpeed * Time.fixedDeltaTime, rb.velocity.y);
    }

    void Flip()
    {
        mustPatrol = false;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        walkSpeed *= -1;
        mustPatrol = true;
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
