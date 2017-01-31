using UnityEngine;
using System.Collections;

public class Movement {

    private float distance = 13f;
    private float time = 5f;
    private bool isWalking;
    private bool movementEnabled;
    
    public Movement(float dist, float t) {
        this.distance = dist;
        this.time = t;
        isWalking = false;
    }
    	
	public void moving (Transform transf, Animator anim, Vector2 input) {

        isWalking = (Mathf.Abs(input.x) + Mathf.Abs(input.y)) > 0;

        if (isWalking) {
            anim.SetBool("isWalking", isWalking);
            anim.SetFloat("x", input.x);
            anim.SetFloat("y", input.y);

            transf.Translate(new Vector3(input.x, input.y, 0).normalized * Time.deltaTime * (distance / time), Space.World);
        }
    }

    public float MovementSpeed { get; set; }
    public bool MovementEnabled { get; set; }
}
