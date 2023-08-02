using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;
using UnityEngine.UIElements;

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
    public float jumpGroundThreshold = 2;
    public Animator playerAnimator;
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
                //rest jump timer
                holdJumpTimer = 0.0f;
            }
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            isHoldingJump = false;
        }

        if (isGrounded == true)
        {
            playerAnimator.SetBool("isGrounded", true);
        }
        else
        {
            playerAnimator.SetBool("isGrounded", false);
        }

        if (isHoldingJump == true)
        {
            playerAnimator.SetBool("isHoldingJump", true);
        }
        else
        {
            playerAnimator.SetBool("isHoldingJump", false);
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


}
