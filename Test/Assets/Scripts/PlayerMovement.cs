using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public float moveSpeed;
	public Rigidbody2D rb;


	// Update is called once per frame
	void Update () {

	}

	void FixedUpdate () {

		//Move ();
		rb.velocity += Vector2.right * moveSpeed * Input.GetAxis ("Horizontal") * Time.deltaTime;
		rb.velocity += Vector2.up * moveSpeed * Input.GetAxis ("Vertical") * Time.deltaTime;

        Debug.Log(Vector2.right);
        Debug.Log(Vector2.up);
	}

	void Move() {
		var horizontal = Input.GetAxis ("Horizontal");
		var vertical = Input.GetAxis ("Vertical");

		if (horizontal < 0) {
			rb.velocity += -Vector2.right * moveSpeed * Time.deltaTime;
		
		} else if (horizontal > 0) {
			rb.velocity += Vector2.right * moveSpeed * Time.deltaTime;
		}

		if (vertical < 0) {
			rb.velocity += -Vector2.up * moveSpeed * Time.deltaTime;

		} else if (vertical > 0) {
			rb.velocity += Vector2.up * moveSpeed * Time.deltaTime;
		}
	}
}