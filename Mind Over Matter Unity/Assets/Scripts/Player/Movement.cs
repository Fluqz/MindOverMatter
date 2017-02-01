using UnityEngine;
using System.Collections;

public class Movement {

    private float distance;
    private float time;
    private bool isWalking;
    private bool movementEnabled;

    private Transform transf;
    private Animator anim;

    public Movement(float dist, float t, Transform trans, Animator ani) {
        this.distance = dist;
        this.time = t;
        this.transf = trans;
        this.anim = ani;

        isWalking = false;
        movementEnabled = true;
    }
    	
	public void move (Vector2 direction) {
        Debug.Log(distance);

        if (MovementEnabled) {

            isWalking = (Mathf.Abs(direction.x) + Mathf.Abs(direction.y)) > 0;

            if (isWalking) {
                anim.SetBool("isWalking", isWalking);
                anim.SetFloat("x", direction.x);
                anim.SetFloat("y", direction.y);

                this.transf.Translate(new Vector3(direction.x, direction.y, 0).normalized * Time.deltaTime * (distance / time), Space.World);
            }
        }
        else {
            anim.SetBool("isWalking", false);
        }
    }


    public float MovementSpeed { get; set; }
    public bool MovementEnabled { get; set; }
}
