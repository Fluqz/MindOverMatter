using UnityEngine;
using System.Collections;
using System.Diagnostics;

using Debug = UnityEngine.Debug;

public class Player : MonoBehaviour {

    public float distance = 13f;
    public float time = 5f;

	private Rigidbody2D rigid;
	protected Animator anim;
    private Transform transf;

    private Vector3 startingPosition;

    private Movement movement;

	void Awake () {
        transf = GetComponent<Transform>();
        movement = new Movement(distance, time);
		rigid = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();

        startingPosition = new Vector3(-13, -4, 0);
        transf.position = startingPosition;
	}

	void Update(){
        movement.moving(transform, anim);
    }

	void FixedUpdate () {
	}
}
