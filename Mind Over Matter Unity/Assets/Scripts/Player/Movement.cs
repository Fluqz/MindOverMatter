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
    	
	public void moving (Transform transf, Animator anim) {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        isWalking = (Mathf.Abs(horizontal) + Mathf.Abs(vertical)) > 0;

        if (isWalking) {
            anim.SetBool("isWalking", isWalking);
            anim.SetFloat("x", horizontal);
            anim.SetFloat("y", vertical);

            transf.Translate(new Vector3(horizontal, vertical, 0).normalized * Time.deltaTime * (distance / time), Space.World);
        }
    }

    public float MovementSpeed { get; set; }
    public bool MovementEnabled { get; set; }
}
