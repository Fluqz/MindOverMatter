using UnityEngine;
using System.Collections;

public class EnemyMovement {

    private float movementSpeed;
    private float reduceMovement;
    private bool isWalking;
    private bool movementEnabled;
    private bool onWall;
    private Vector2 direction;

    private Animator anim;
    private Transform transf;
    private Rigidbody2D rigid;

    public EnemyMovement(float speed, GameObject go) {
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

    public void Move(Vector2 input, Vector3 destination) {

        if (MovementEnabled) {

            isWalking = (Mathf.Abs(input.x) + Mathf.Abs(input.y)) > 0;
            anim.SetBool("isWalking", isWalking);

            anim.SetFloat("x", input.x);
            anim.SetFloat("y", input.y);

            if (isWalking) {
                transf.position = Vector3.MoveTowards(transf.position, destination, movementSpeed / 45);
                direction = new Vector2(input.x, input.y).normalized;
                anim.SetFloat("DirectionX", direction.x);
                anim.SetFloat("DirectionY", direction.y);
            }
        }
    }

    public void UpdateVelocity(float reduce) {
        this.reduceMovement = reduce;
    }

    public float MovementSpeed { get { return movementSpeed; } }
    public bool MovementEnabled { get { return movementEnabled; } set { rigid.velocity = Vector2.zero; movementEnabled = value; } }
    public bool OnWall { get { return onWall; } set { onWall = value; } }
    public float ReduceMovement { set { reduceMovement = value; } }
    public bool IsWalking { set { isWalking = value; } get { return isWalking; } }
}
