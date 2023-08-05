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
    
    [SerializeField] Transform[] Points;

    private int pointsIndex;

    // Start is called before the first frame update
    void Start()
    {
        localScale = transform.localScale;
        transform.position = Points[pointsIndex].transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        if (pointsIndex <= Points.Length -1)
        {
            transform.position = Vector2.MoveTowards(transform.position, Points[pointsIndex].transform.position, moveSpeed*Time.deltaTime);

            if (transform.position == Points[pointsIndex].transform.position)
            {
                pointsIndex += 1;
            }
        }
    }
    private void FixedUpdate()
    {
        
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
