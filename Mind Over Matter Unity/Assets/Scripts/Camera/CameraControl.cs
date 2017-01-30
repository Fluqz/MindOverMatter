using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {

	// Player is target
	public Transform target;
    private Vector3 targetPosition;
    private float followSpeed = 3f;

    private Camera cam;
    private int ppu = 64;

	void Awake(){
		cam = GetComponent<Camera> ();

        setCamToOrthographicSize();
        Debug.Log ("Ortho camera pixel perfect size is: " + cam.orthographicSize);
	}

	void Update () {
		if (target) {
            targetPosition = new Vector3(target.transform.position.x, target.transform.position.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);
            //transform.position = Vector3.Lerp(transform.position, targetPosition, 0.05f) + new Vector3(0.03f, 0.05f, 0);
        }
    }

    void setCamToOrthographicSize() {
        // Sets Orthographic size to fit for 64x64 px sprites
        cam.orthographicSize = (Screen.height / ppu / 2.0f);
    }

}

