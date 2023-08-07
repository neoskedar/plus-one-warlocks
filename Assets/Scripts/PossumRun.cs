using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PossumRun : StateMachineBehaviour
{
    public float moveSpeed;
    private Vector2 currentTarget;
    public Transform leftTarget;
    public Transform rightTarget;
    public Rigidbody2D rb;
    private bool moveLeft = true;
    public int laps = 0;

    PossumBoss possumBoss;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        possumBoss = animator.GetComponentInParent<PossumBoss>();
        rb = animator.GetComponentInParent<Rigidbody2D>();
        leftTarget = GameObject.FindGameObjectWithTag("Left").transform;
        rightTarget = GameObject.FindGameObjectWithTag("Right").transform;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (moveLeft)
        {
            currentTarget = new Vector2(leftTarget.position.x, rb.position.y);
            Debug.Log("Move Left");
        }
        else
        {
            currentTarget = new Vector2(rightTarget.position.x, rb.position.y);
            Debug.Log("Move Right");
        }
        
        Vector2 newPos = Vector2.MoveTowards(rb.position, currentTarget, moveSpeed * Time.fixedDeltaTime);
        rb.MovePosition(newPos);


        if (rb.position.x == leftTarget.position.x)
        {
            moveLeft = false;
            possumBoss.dirX = -1;
            laps++;
        }
        else if (rb.position.x == rightTarget.position.x)
        {
            moveLeft = true;
            possumBoss.dirX = 1;
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

}
