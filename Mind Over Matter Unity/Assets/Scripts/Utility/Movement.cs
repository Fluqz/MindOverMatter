﻿using UnityEngine;
using System.Collections;

public class Movement {

    private float movementSpeed;
    private float reduceMovement;
    private bool isWalking;
    private bool movementEnabled;
    private bool onWall;
    private Vector2 direction;

    private Animator anim;
    private Transform transf;
    private Rigidbody2D rigid;

    public Movement(float speed, GameObject go) {
        this.movementSpeed = speed;
        this.anim = go.GetComponent<Animator>();
        this.rigid = go.GetComponent<Rigidbody2D>();
        this.transf = go.GetComponent<Transform>();

        this.isWalking = false;
        this.movementEnabled = true;
        this.onWall = false;
        this.reduceMovement = 100;
        this.direction = new Vector2(0, -1);
    }
    	
	public void move (Vector2 playerInput) {

        if (MovementEnabled) {

            isWalking = (Mathf.Abs(playerInput.x) + Mathf.Abs(playerInput.y)) > 0;
            anim.SetBool("isWalking", isWalking);

            anim.SetFloat("x", playerInput.x);
            anim.SetFloat("y", playerInput.y);
            rigid.velocity = playerInput;

            if (isWalking) {
                this.rigid.velocity = this.rigid.velocity.normalized * ((movementSpeed / 100) * reduceMovement);
                direction = new Vector2(playerInput.x, playerInput.y).normalized;
                anim.SetFloat("DirectionX", direction.x);
                anim.SetFloat("DirectionY", direction.y);
            }
        }
        else this.rigid.velocity = Vector2.zero;
    }

    public void UpdateVelocity(float reduce) {
        this.reduceMovement = reduce;
    }

    public void SetPlayerDirection() {
        PlayerInformation.Direction = direction;
    }

    public float MovementSpeed { get { return movementSpeed; } }
    public bool MovementEnabled { get { return movementEnabled; } set { rigid.velocity = Vector2.zero; movementEnabled = value; } }
    public bool OnWall { get { return onWall; } set { onWall = value; } }
    public float ReduceMovement { set { reduceMovement = value; } }
}
