using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class PossumBoss : MonoBehaviour
{
    public Vector2 velocity;
    private Vector2 localScale;
    float attackDelay = 0.5f;
    private float dirX = 1f;
    private bool facingRight;
    public float moveSpeed = 5f;
    public float timer;
    public float seconds = 10f;
    private bool canMove;

    // Start is called before the first frame update
    void Start()
    {
        localScale = transform.localScale;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        CheckWhereToFace();

        if (timer <= seconds)
        {
            timer += Time.fixedDeltaTime;
            canMove = false;

        }
        else if (timer >= seconds)
        {
            timer = 0f;
            canMove = true;
        }

        if (canMove)
        {
            if (!facingRight)
                transform.Translate(Vector2.right * moveSpeed * Time.deltaTime, Space.World);
            if (facingRight)
                transform.Translate(Vector2.left * moveSpeed * Time.deltaTime, Space.World);
        }
        if (transform.position.x <= 2)
        {
            dirX *= -1;
            timer = 0f;
            canMove = false;
        } else if (transform.position.x >= 35)
        {
            dirX *= -1;
            timer = 0f;
            canMove = false;
        } 

    }
    private void LateUpdate()
    {

    }

    void CheckWhereToFace()
    {
        if (dirX > 0)
            facingRight = true;
        else if (dirX < 0)
            facingRight= false;

        if (((facingRight) && (localScale.x < 0)) || ((!facingRight) && (localScale.x > 0)))
            localScale.x *= -1;

        transform.localScale = localScale;
        
    }
}
