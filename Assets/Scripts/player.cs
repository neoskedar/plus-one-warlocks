using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{
    public float gravity;
    public Vector2 velocity;
    public float maxxVelocity = 100;
    public float maxAcceleration = 10;
    public float acceleration = 10;
    public float jumpVelocity = 20;
    public float groundHeight = 10;
    public float distance = 0;
    public bool isGrounded = false;
    public bool isHoldingJump = false;
    public float maxHoldJumpTime = 0.4f;
    public float holdJumpTimer = 0.0f;
    public float jumpGroundThreshold = 1;
    public Animator playerAnimator;

    private string currentAnimState;

    //Animation States
    const string PLAYER_RUN = "player_run";
    const string PLAYER_JUMP = "player_jump";
    const string PLAYER_FALL = "player_fall";
    const string PLAYER_PEAK = "playerpeakjump";

    void Start()
    {
        
    }

    void Update()
    {
        //get current position relative to ground
        Vector2 pos = transform.position;
        float groundDistance = Mathf.Abs(pos.y - groundHeight);

        //check is touching ground or close enough to ground
        if (isGrounded || groundDistance <= jumpGroundThreshold)
        {
            //allow jump
            if(Input.GetKeyDown(KeyCode.Space))
            {
                isGrounded = false;
                velocity.y = jumpVelocity;
                isHoldingJump = true;
                //reset jump timer
                holdJumpTimer = 0.0f;
                ChangeAnimationState(PLAYER_JUMP);
            }
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            isHoldingJump = false;
        }
        if (isGrounded == true)
        {
            ChangeAnimationState(PLAYER_RUN);
        }
        if (isHoldingJump == false && isGrounded == false)
        {
            ChangeAnimationState(PLAYER_PEAK);
        }
    }

    private void FixedUpdate()
    {
        //grab current position
        Vector2 pos = transform.position;

        //while in air
        if (!isGrounded)
        {
            if (isHoldingJump)
            {
                holdJumpTimer += Time.fixedDeltaTime;
                if(holdJumpTimer >= maxHoldJumpTime)
                {
                    //when you reach max time, force no more jump
                    isHoldingJump = false;
                }
            }

            pos.y += velocity.y * Time.fixedDeltaTime;

            if (!isHoldingJump)
            {
                velocity.y += gravity * Time.fixedDeltaTime;
            }

            //check if touching ground
            if(pos.y <= groundHeight)
            {
                pos.y = groundHeight;
                isGrounded = true;
            }
        }

        distance += velocity.x * Time.fixedDeltaTime;

        if (isGrounded)
        {
            float velocityRatio = velocity.x / maxxVelocity;
            acceleration = maxAcceleration * (1 - velocityRatio);

            velocity.x += acceleration * Time.fixedDeltaTime;
            
            if(velocity.x >= maxxVelocity)
            {
                velocity.x = maxxVelocity;
            }
        }

        //update position
        transform.position = pos;
    }
    void ChangeAnimationState(string newAnimState)
    {
        //Stop the same animation from interrupting itself
        if (currentAnimState == newAnimState) return;

        //Play the Animation
        playerAnimator.Play(newAnimState);

        //reassign the current state
        currentAnimState = newAnimState;
    }
    void OnTriggerEnter2D(Collider2D collision)
    {

        Debug.Log(collision.gameObject.name + " : " + gameObject.name + " : " + Time.deltaTime);

        if (collision.tag == "Hazard")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
