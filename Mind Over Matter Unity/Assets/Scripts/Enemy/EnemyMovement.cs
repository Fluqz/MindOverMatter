using UnityEngine;
using System.Collections;

public class EnemyMovement : Movement {

    private EnemyInformation enemyInfo;

    public EnemyMovement(EnemyInformation enemyInfo, GameObject go) {
        this.enemyInfo = enemyInfo;
        this.movementSpeed = 0;
        this.MaxMovementSpeed = enemyInfo.MovementSpeed;
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

            rigid.velocity += ((MaxMovementSpeed / 100) * reduceMovement) * input.normalized * Time.fixedDeltaTime;
            enemyInfo.Position = new Vector3(transf.position.x, transf.position.y, transf.position.y/40);
            
            anim.SetBool("isWalking", isWalking);
            anim.SetFloat("x", input.x);
            anim.SetFloat("y", input.y);

            direction = new Vector2(input.x, input.y).normalized;
            if (direction != Vector2.zero) {
                anim.SetFloat("DirectionX", direction.x);
                anim.SetFloat("DirectionY", direction.y);
                enemyInfo.Direction = direction;
            }
        }
        else {
            this.rigid.velocity = Vector2.zero;
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
