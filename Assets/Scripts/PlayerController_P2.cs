using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController_P2 : PhysicsObject
{
    public float maxSpeed = 7;
    public float jumpTakeOffSpeed = 7f;


    //Use this for initialization
    void Start()
    {
        
    }

    //Update is called once per frame
    protected override void ComputeVelocity()
    {
        Vector2 move = Vector2.zero;

        move.x = Input.GetAxis("Horizontal_P2");
        if (Input.GetButtonDown("Jump_P2") && grounded)
            velocity.y = jumpTakeOffSpeed;
        else if (Input.GetButtonUp("Jump_P2") && velocity.y > 0)
            velocity.y = velocity.y * .5f;

        targetVelocity = move * maxSpeed;
    }
}