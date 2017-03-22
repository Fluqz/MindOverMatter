using UnityEngine;
using System.Collections;

public class Movement {
    protected float movementSpeed;
    protected float MaxMovementSpeed;
    protected float accelaration;
    protected float reduceMovement;
    protected bool isWalking;
    protected bool movementEnabled;
    protected bool onWall;
    protected bool stopping;
    protected Vector2 direction;

    protected Animator anim;
    protected Transform transf;
    protected Rigidbody2D rigid;
    protected SpriteRenderer render;

    public virtual void Move() { }
    public virtual void Move(Vector2 input) { }
    public virtual void Move(Vector2 input, Vector3 destination) { }
}
