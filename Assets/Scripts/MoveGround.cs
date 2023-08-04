using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveGround : MonoBehaviour
{
    public float depth = 1;
    player player;

    private void Awake()
    {
        player = GameObject.Find("Player").GetComponent<player>();
    }
    void FixedUpdate()
    {
        float realVelocity = player.velocity.x / depth;
        Vector2 pos = transform.position;

        pos.x -= realVelocity * Time.fixedDeltaTime;

        if (pos.x <= -20)
            pos.x = 56;


        transform.position = pos;
    }
}
