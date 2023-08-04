using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundHazards : MonoBehaviour
{
    public float depth = 1;

    player player;

    private void Awake()
    {
        player = GameObject.Find("Player").GetComponent<player>();
    }
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float realVelocity = player.velocity.x / depth;
        Vector2 pos = transform.position;

        pos.x -= realVelocity * Time.fixedDeltaTime;

        if (pos.x <= -25)
        {
            Destroy(this.gameObject);
        }


        transform.position = pos;
    }
}
