using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {

	// Player is target
	public Transform player;
    private Vector3 currentPlayerPosition;

    private Camera cam;
    private Vector3 currentCameraPosition;
    private float followSpeed = 3f;
    private int ppu = 64;
    private Vector2 adjustToCenter = new Vector2(.5f, 1);

	void Awake(){
		cam = GetComponent<Camera> ();
        setCamToOrthographicSize();
        Debug.Log ("Ortho camera pixel perfect size is: " + cam.orthographicSize);

        currentPlayerPosition = new Vector3(player.transform.position.x + adjustToCenter.x, player.transform.position.y + adjustToCenter.y, transform.position.z);
        transform.position = currentPlayerPosition;
    }

	void Update () {
		if (player) {
            currentPlayerPosition = new Vector3(player.transform.position.x + adjustToCenter.x, player.transform.position.y + adjustToCenter.y, transform.position.z);
            transform.position = currentCameraPosition = Vector3.Lerp(transform.position, currentPlayerPosition, followSpeed * Time.deltaTime);
        }
    }

    void setCamToOrthographicSize() {
        // Sets Orthographic size to fit for 64x64 px sprites
        cam.orthographicSize = (Screen.height / ppu / 2.0f);
    }

    /*public float RoundToNearestPixel(float unityUnits) {
        float valueInPixels = unityUnits * pixelToUnits;
        valueInPixels = Mathf.Round(valueInPixels);
        float roundedUnityUnits = valueInPixels * (1 / pixelToUnits);
        return roundedUnityUnits;
    }*/
}

