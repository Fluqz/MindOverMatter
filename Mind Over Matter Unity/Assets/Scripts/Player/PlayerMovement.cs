using UnityEngine;
using System.Collections;

public class PlayerMovement : Movement {
    
    public PlayerMovement(float speed, GameObject go) {
        this.movementSpeed = 0;
        this.MaxMovementSpeed = speed;
        this.anim = go.GetComponent<Animator>();
        this.rigid = go.GetComponent<Rigidbody2D>();
        this.transf = go.GetComponent<Transform>();

        this.isWalking = false;
        this.movementEnabled = true;
        this.onWall = false;
        this.reduceMovement = 100;
        this.direction = new Vector2(0, -1);
        this.accelaration = .5f;
    }

    public override void Move(Vector2 input) {

        if (MovementEnabled) {

            isWalking = (Mathf.Abs(input.x) + Mathf.Abs(input.y)) > 0;
            anim.SetBool("isWalking", isWalking);

            anim.SetFloat("x", input.x);
            anim.SetFloat("y", input.y);
            rigid.velocity = input;

            if (isWalking) {
                if (MovementSpeed < MaxMovementSpeed) {
                    movementSpeed += accelaration;
                }
                this.rigid.velocity = this.rigid.velocity.normalized * ((movementSpeed / 100) * reduceMovement);
                direction = new Vector2(input.x, input.y).normalized;
                anim.SetFloat("DirectionX", direction.x);
                anim.SetFloat("DirectionY", direction.y);
            }
            else {
                rigid.velocity = Vector2.zero;
                movementSpeed = 0f;
            }
        }
        else {
            this.rigid.velocity = Vector2.zero;
            movementSpeed = 0;
        }
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
    public bool IsWalking { set { isWalking = value; } get { return isWalking; } }
}
