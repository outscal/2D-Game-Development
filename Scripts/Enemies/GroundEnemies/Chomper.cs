using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chomper : MonoBehaviour
{
    public float walkSpeed;
    public float runSpeed;
    public bool isFacingRight = true;
    float localScaleX;
    public Animator animator;
    public Transform LeftBound, RightBound;

    public float attackDistance;
    public float attackCoolDown;

    public bool playerDetected;

    public enum States
    {
        idle, running, walking, attacking, dead,
    }

    public States currentState;

    private void Start()
    {
        currentState = States.walking;
    }
    private void Update()
    {
        if (shouldFlip())
            Flip();

        if (playerDetected)
            Walking();
        else
            Running();

    }

    private void Walking()
    {
        if (currentState != States.attacking)
            if (isFacingRight)
                transform.Translate(Vector2.right * walkSpeed * Time.deltaTime);
            else
                transform.Translate(Vector2.left * walkSpeed * Time.deltaTime);
    }

    private void Running()
    {
        if (currentState != States.attacking)
        {
            if (currentState != States.running)
            {
                currentState = States.running;
                animator.SetBool("isRunning", true);
            }

            if (isFacingRight)
                transform.Translate(Vector2.right * runSpeed * Time.deltaTime);
            else
                transform.Translate(Vector2.left * runSpeed * Time.deltaTime);

            if (playerIsInRange())
                StartCoroutine(Attack());
        }
    }

    private bool playerIsInRange()
    {
        if (Vector2.Distance(transform.localPosition, PlayerController.instance.gameObject.transform.localPosition) < attackDistance)
            return true;
        else
            return false;

    }

    private IEnumerator Attack()
    {
        currentState = States.attacking;
        animator.SetTrigger("Attack");
        PlayerStats.instance.DamagePlayer();

        animator.SetBool("inCoolDown", true);
        yield return new WaitForSeconds(attackCoolDown);
        animator.SetBool("inCoolDown", false);


        if (playerDetected && playerIsInRange() && currentState != States.attacking)
        {
            StartCoroutine(Attack());
        }
        else if (!playerDetected && !playerIsInRange())
        {
            currentState = States.walking;
        }

    }

    private bool shouldFlip()
    {
        if ((transform.localPosition.x > RightBound.localPosition.x && isFacingRight)
        || (transform.localPosition.x < LeftBound.localPosition.x && !isFacingRight))
            return true;
        else
            return false;
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        localScaleX = transform.localScale.x;
        localScaleX *= -1;
        transform.localScale = new Vector2(localScaleX, transform.localScale.y);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<PlayerController>() != null)
        {
            playerDetected = true;
        }
    }





}
