using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController_P1 : PhysicsObject
{
    public float maxSpeed = 7;
    public float jumpTakeOffSpeed = 7f;

    private SpriteRenderer spriteRenderer;
    private Animator animator;

    //Use this for initialization
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    //Update is called once per frame
    protected override void ComputeVelocity()
    {
        Vector2 move = Vector2.zero;

        move.x = Input.GetAxis("Horizontal_P1");
        if (Input.GetButtonDown("Jump_P1") && grounded)
            velocity.y = jumpTakeOffSpeed;
        else if (Input.GetButtonUp("Jump_P1") && velocity.y > 0)
            velocity.y = velocity.y * .5f;


        bool flipSprite = (spriteRenderer.flipX ? (move.x > 0.1f) : (move.x < 0.01f));
        if (flipSprite)
        {
            spriteRenderer.flipX = !spriteRenderer.flipX;
        }

        animator.SetBool("grounded", grounded);
        animator.SetFloat("velocityx", Mathf.Abs(velocity.x) / maxSpeed);

        targetVelocity = move * maxSpeed;
    }
}