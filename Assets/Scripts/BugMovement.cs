using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugMovement : MonoBehaviour
{
    Animator animator;
    public Rigidbody2D bugRigid;
    private float latestDirectionChangeTime;
    private readonly float directionChangeTime = 2f;
    private float characterVelocity = 0.5f;
    private Vector2 movementDirection;
    private Vector2 movementPerSecond;
   

    // Start is called before the first frame update
    void Start()
    {
        latestDirectionChangeTime = 0f;
        calcuateNewMovementVector();
        animator = GetComponent<Animator>();
        animator.SetBool("isMoving", true);
    }

    void calcuateNewMovementVector()
    {

        //create a random direction vector with the magnitude of 1, later multiply it with the velocity of the enemy
        movementDirection = new Vector2(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f)).normalized;
        movementPerSecond = movementDirection * characterVelocity;
    }

    void Update()
    {
        //if the changeTime was reached, calculate a new movement vector
        if (Time.time - latestDirectionChangeTime < directionChangeTime)
        {
            transform.position = new Vector2(transform.position.x + (movementPerSecond.x * Time.deltaTime),
            transform.position.y + (movementPerSecond.y * Time.deltaTime));
            animator.SetBool("isMoving", true);
        }
        else if (Time.time - latestDirectionChangeTime < 5)
        {
            bugRigid.constraints = RigidbodyConstraints2D.FreezePosition;
            animator.SetBool("isMoving", false);


        }
        else
        {
            bugRigid.constraints = RigidbodyConstraints2D.None;
            latestDirectionChangeTime = Time.time;
            calcuateNewMovementVector();
        }

        //move enemy: 
        //transform.position = new Vector2(transform.position.x + (movementPerSecond.x * Time.deltaTime),
        //transform.position.y + (movementPerSecond.y * Time.deltaTime));

    }
    IEnumerator ExampleCoroutine()
    {
        yield return new WaitForSeconds(5);

    }
}
