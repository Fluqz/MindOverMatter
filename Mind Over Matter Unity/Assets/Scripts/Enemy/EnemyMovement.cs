using UnityEngine;
using System.Collections;

public class EnemyMovement : Movement {
    
    public EnemyMovement(float speed, GameObject go) {
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
        this.accelaration = .05f;
    }

    public override void Move(Vector2 input) {

        if (MovementEnabled) {

            isWalking = (Mathf.Abs(input.x) + Mathf.Abs(input.y)) > 0;
            anim.SetBool("isWalking", isWalking);

            anim.SetFloat("x", input.x);
            anim.SetFloat("y", input.y);

            if (isWalking) {
                if (movementSpeed < MaxMovementSpeed) {
                    movementSpeed += accelaration;
                }
                transf.position = Vector3.MoveTowards(transf.position, PlayerInformation.Position, ((movementSpeed / 100) * reduceMovement) / 45);
                transf.position = new Vector3(transf.position.x, transf.position.y, transf.position.y);
                direction = new Vector2(input.x, input.y).normalized;
                anim.SetFloat("DirectionX", direction.x);
                anim.SetFloat("DirectionY", direction.y);
            }
        }
        else {
            if(movementSpeed <= 0)
                movementSpeed -= accelaration;
        }
    }

    public void UpdateVelocity(float reduce) {
        this.reduceMovement = reduce;
    }

    public float MovementSpeed { get { return movementSpeed; } }
    public bool MovementEnabled { get { return movementEnabled; } set { rigid.velocity = Vector2.zero; movementEnabled = value; } }
    public bool OnWall { get { return onWall; } set { onWall = value; } }
    public float ReduceMovement { set { reduceMovement = value; } }
    public Vector2 Direction{ get { return direction; } }
    public bool IsWalking { set { isWalking = value; } get { return isWalking; } }
}
