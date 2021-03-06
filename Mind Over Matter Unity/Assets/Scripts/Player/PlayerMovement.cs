﻿using UnityEngine;
using System.Collections;

public class PlayerMovement : Movement {
    
    public PlayerMovement(float speed, GameObject go) {
        this.movementSpeed = 0;
        this.MaxMovementSpeed = speed > 0 ? speed : 1;
        this.anim = go.GetComponent<Animator>();
        this.rigid = go.GetComponent<Rigidbody2D>();
        this.transf = go.GetComponent<Transform>();

        this.isWalking = false;
        this.movementEnabled = true;
        this.onWall = false;
        this.reduceMovement = 100;
        this.direction = new Vector2(0, -1);
    }

    public override void Move(Vector2 input) {

        if (MovementEnabled) {

            isWalking = (Mathf.Abs(input.x) + Mathf.Abs(input.y)) > 0;

            rigid.velocity += (((MaxMovementSpeed / 100) * reduceMovement) * input.normalized * Time.fixedDeltaTime);        
            PlayerInformation.Position = new Vector3(transf.position.x, transf.position.y, transf.position.y/40f);


            anim.SetBool("isWalking", isWalking);
            anim.SetFloat("x", input.x);
            anim.SetFloat("y", input.y);

            direction = new Vector2(input.x, input.y).normalized;
            if (direction != Vector2.zero) {
                PlayerInformation.Direction = direction;
                anim.SetFloat("DirectionX", direction.x);
                anim.SetFloat("DirectionY", direction.y);
            }
        }
        else {
            this.rigid.velocity = Vector2.zero;
        }
    }

    public void UpdateVelocity(float reducePercent) {
        this.reduceMovement = reducePercent;
    }
    
    public float MovementSpeed { get { return movementSpeed; } }
    public bool MovementEnabled { get { return movementEnabled; } set { rigid.velocity = Vector2.zero; movementEnabled = value; } }
    public bool OnWall { get { return onWall; } set { onWall = value; } }
    public float ReduceMovement { set { reduceMovement = value; } }
    public bool IsWalking { set { isWalking = value; } get { return isWalking; } }
}
