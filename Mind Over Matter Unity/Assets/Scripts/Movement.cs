using UnityEngine;
using System.Collections;

public class Movement {

    private float distance;
    private float time;
    private bool isWalking;
    private bool movementEnabled;
    private Vector2 direction;

    private Transform transf;
    private Animator anim;

    public Movement(float dist, float t, Transform trans, Animator ani) {
        this.distance = dist;
        this.time = t;
        this.transf = trans;
        this.anim = ani;

        this.isWalking = false;
        this.movementEnabled = true;
        this.direction = new Vector2(0, -1);
    }
    	
	public void move (Vector2 playerInput) {

        if (MovementEnabled) {

            isWalking = (Mathf.Abs(playerInput.x) + Mathf.Abs(playerInput.y)) > 0;
            anim.SetBool("isWalking", isWalking);

            anim.SetFloat("x", playerInput.x);
            anim.SetFloat("y", playerInput.y);

            if (isWalking) {
                this.transf.Translate(new Vector3(playerInput.x, playerInput.y, 0).normalized * (distance / time) * Time.deltaTime, Space.World);
                anim.SetFloat("DirectionX", direction.x);
                anim.SetFloat("DirectionY", direction.y);
            }
            direction = new Vector2(playerInput.x, playerInput.y).normalized;

        }
        else {
            anim.SetBool("isWalking", false);
        }
    }

    public float MovementSpeed { get { return (distance / time); } }
    public bool MovementEnabled { get; set; }
}
