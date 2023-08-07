using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class PossumBoss : MonoBehaviour
{
    private Vector2 localScale;
    public float dirX = 1f;
    private bool facingRight;

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
