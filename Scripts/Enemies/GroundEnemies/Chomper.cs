using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chomper : MonoBehaviour
{

    [Header("Chomper Health")]
    public float maxHealth;
    [HideInInspector]
    public float currenthealth;

    [Header("Chomper Movement")]
    public float walkSpeed;
    public float runSpeed;
    public bool isFacingRight = true;
    public States currentState;

    [Header("Unity Essentials")]
    public Animator animator;
    public Transform LeftBound, RightBound;
    IEnumerator AttackCo;

    float localScaleX;

    [Header("Attack Parameters")]
    public float attackDistance;
    public float attackCoolDown;
    public bool isPlayerDetected = false;
    bool inAttack;


    private void Start()
    {
        animator.SetBool("isWalking", true);
        currenthealth = maxHealth;
    }

    public enum States
    {
        coolDown, running, walking, attacking, dead,
    }



    private void Update()
    {


        if (shouldFlip())
            Flip();

        if (!isPlayerDetected)
            Walking();
        else if (isPlayerDetected && !playerIsInRange())
            Running();

        if (canAttack() && isPlayerDetected &&
             !PlayerIsNotInFront())
        {
            AttackCo = Attack();
            StartCoroutine(AttackCo);
        }
    }

    private void Walking()
    {
        if (currentState != States.walking)
            currentState = States.walking;

        if (isFacingRight)
            transform.Translate(Vector2.right * walkSpeed * Time.deltaTime);
        else
            transform.Translate(Vector2.left * walkSpeed * Time.deltaTime);

    }

    private void Running()
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

    }

    private bool canAttack()
    {
        return playerIsInRange() && !inAttack;
    }

    private bool playerIsInRange()
    {
        if (Mathf.Abs(transform.position.x - PlayerController.instance.transform.position.x) < attackDistance)
            return true;
        else
            return false;

    }

    private IEnumerator Attack()
    {
        Debug.Log("In Attack Coroutine");
        inAttack = true;
        if (PlayerIsNotInFront())
            Flip();
        animator.SetBool("isRunning", false);
        animator.SetBool("isWalking", false);
        currentState = States.coolDown;
        animator.SetBool("inCoolDown", true);
        yield return new WaitForSeconds(attackCoolDown);
        currentState = States.attacking;
        animator.SetBool("inCoolDown", false);
        animator.SetTrigger("Attack");
        yield return new WaitForSeconds(0.4f);
        PlayerStats.instance.DamagePlayer();
        yield return new WaitForSeconds(0.5f);
        inAttack = false;
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


    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<PlayerController>() != null)
        {
            if (!PlayerStats.instance.isDead)
                isPlayerDetected = true;
            else
                isPlayerDetected = false;

            if (PlayerIsNotInFront())
                Flip();
        }
    }

    private bool PlayerIsNotInFront()
    {
        return (PlayerController.instance.transform.position.x > transform.position.x && !isFacingRight)
             || (PlayerController.instance.transform.position.x < transform.position.x && isFacingRight);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<PlayerController>() != null)
        {
            isPlayerDetected = false;
            if (AttackCo != null)
                StopCoroutine(AttackCo);
            animator.SetBool("isWalking", true);
            animator.SetBool("isRunning", false);
            animator.SetBool("inCoolDown", false);
            animator.ResetTrigger("Attack");
            inAttack = false;
        }
    }
}
