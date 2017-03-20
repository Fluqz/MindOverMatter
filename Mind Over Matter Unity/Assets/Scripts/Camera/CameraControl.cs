using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {

	// Player is target
	public Transform player;
    private Vector3 currentPlayerPosition;

    private Camera cam;
    private Vector3 currentCameraPosition;
    private float followSpeed = 2f;
    private int ppu = 64;
    private Player p;
    private Vector3 swingPosition;

	void Awake(){
		cam = GetComponent<Camera> ();
        setCamToOrthographicSize();


        Debug.Log ("Ortho camera pixel perfect size is: " + cam.orthographicSize);

        currentPlayerPosition = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);
        transform.position = currentPlayerPosition;
    }

    void Start() {
        if (player == null)
            player = gameObject.transform.Find("Player");
        p = player.GetComponent<Player>();

        Job.make(SetSwingPoint());
    }

    IEnumerator SetSwingPoint() {
        while (true) {
            swingPosition = new Vector3(Random.Range(.1f, 1.5f), Random.Range(.1f, 1.5f), 0);

            float wait = Random.Range(2, 6);
            yield return new WaitForSeconds(wait);
        }
    }

    void UpdateSwing() {
        Vector3.MoveTowards(transform.position, swingPosition, 1f);
    }

	void Update () {

        if (player) {
            MoveTowardsPlayer();
        }
    }

    void MoveTowardsPlayer() {
        Vector2 input = (-1) * (PlayerInformation.Direction * 2f);
        currentPlayerPosition = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);

        if (p.PlayerInput.Movement.IsWalking) {
            currentPlayerPosition -= new Vector3(input.x, input.y, 0);
            float distance = Vector3.Distance(currentCameraPosition, currentPlayerPosition);
            transform.position = currentCameraPosition = Vector3.MoveTowards(transform.position, currentPlayerPosition, followSpeed * distance * Time.deltaTime);
        }
        transform.position = currentCameraPosition = Vector3.MoveTowards(transform.position, currentPlayerPosition, followSpeed / 2 * Time.deltaTime);
    }

    float smoothstep(float edge0, float edge1, float x) {
        // Scale, bias and saturate x to 0..1 range
        x = Mathf.Clamp((x - edge0) / (edge1 - edge0), 0f, 1f);
        // Evaluate polynomial
        return x * x * (3 - 2 * x);
    }

    void setCamToOrthographicSize() {
        // Sets Orthographic size to fit for 64x64 px sprites
        cam.orthographicSize = (Screen.height / ppu / 2.0f);
    }

    public float RoundToNearestPixel(float unityUnits) {
        float valueInPixels = unityUnits * ppu;
        valueInPixels = Mathf.Round(valueInPixels);
        float roundedUnityUnits = valueInPixels * (1 / ppu);
        return roundedUnityUnits;
    }
}

 