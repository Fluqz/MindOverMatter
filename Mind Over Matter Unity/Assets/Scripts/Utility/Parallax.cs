using UnityEngine;
using System.Collections;

public class Parallax : MonoBehaviour {

    [SerializeField]
    private float speed;

    private Transform cam;
    private Vector3 lastCam;

	void Start () {
        cam = Camera.main.transform;
        lastCam = cam.position;
	}

	void Update () {
        this.transform.position += (cam.position - lastCam) * speed;
        lastCam = cam.position;
    }
}
