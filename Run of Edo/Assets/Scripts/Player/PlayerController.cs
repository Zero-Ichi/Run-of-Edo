﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerController : PhysicsObject
{

    protected float maxSpeed = 0;
    [SerializeField]
    protected float jumpTakeOffSpeed = 8;
    protected bool ForceAlive;

    protected SpriteRenderer spriteRenderer;
    //protected Animator animator;


    public bool IsHurt { get; set; }
    public bool IsDead { get; set; }

    protected override void Awake()
    {
        base.Awake();
        spriteRenderer = GetComponent<SpriteRenderer>();
        //animator = GetComponent<Animator>();

    }
    protected override void Update()
    {
        if (!IsDead && GameManager.IsStart)
        {
            base.Update();
        }
        if (ForceAlive)
        {
            Relive();
        }
    }

    protected override void ComputeVelocity()
    {
        Vector2 move = Vector2.zero;

        move.x = Vector2.right.x;
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Jump(jumpTakeOffSpeed);
        }
        else if (Input.GetButtonUp("Jump"))
        {
            if (velocity.y > 0)
            {
                velocity.y = velocity.y * .25f;
            }
        }
        bool flipSprite = (spriteRenderer.flipX ? move.x > 0.01f : move.x < -0.01f);
        if (flipSprite)
        {
            spriteRenderer.flipX = !spriteRenderer.flipX;
        }

        //animator.SetBool("Grounded", isGrounded);
        //animator.SetFloat("VelocityY", velocity.y);
        TargetVelocity = move * maxSpeed;

    }


    public void Jump(float jumpValue)
    {
        velocity.y = jumpValue;
        isGrounded = true;
    }

    public void Dead()
    {
        this.IsDead = true;
        GetComponent<Rigidbody2D>().constraints =  RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
        //animator.SetBool("IsDead", this.IsDead);
        GameManager.StopGame();
    }
    public void Relive()
    {
        this.IsDead = false;
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
        //animator.SetBool("IsDead", this.IsDead);
        GameManager.StartGame();
    }

    public void Hurt()
    {
        IsHurt = !IsHurt;
        //animator.SetBool("Hurt", IsHurt);
    }
}