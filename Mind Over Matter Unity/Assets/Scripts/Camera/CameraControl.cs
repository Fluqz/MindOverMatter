using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {

	// Player is target
	public Transform player;
    private Vector3 playerPosition;
    private float followSpeed = 3f;

    private Camera cam;
    private Vector3 cameraPosition;
    private int ppu = 64;

	void Awake(){
		cam = GetComponent<Camera> ();
        setCamToOrthographicSize();
        Debug.Log ("Ortho camera pixel perfect size is: " + cam.orthographicSize);
	}

	void Update () {
		if (player) {
            playerPosition = new Vector3(player.transform.position.x+.5f, player.transform.position.y, transform.position.z); // <------- CENTER CAMERA
            cameraPosition = transform.position = Vector3.Lerp(transform.position, playerPosition, followSpeed * Time.deltaTime);
            //parallax.Move(Vector3.Distance(playerPosition, cameraPosition));
        }
    }

    void setCamToOrthographicSize() {
        // Sets Orthographic size to fit for 64x64 px sprites
        cam.orthographicSize = (Screen.height / ppu / 2.0f);
    }

}

