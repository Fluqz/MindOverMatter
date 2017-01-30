using UnityEngine;
using System.Collections;

public class CameraShaking : MonoBehaviour {

    public float speed = 0.5f;
    private float xRnd, yRnd;

    void Randomize(int min, int max) {
        xRnd = (float)Random.Range(min, max);
        xRnd /= 100;
        yRnd = (float)Random.Range(min, max);
        yRnd /= 100;
    }

    void Update () {
            Randomize(-20, 20);
            transform.position = Vector3.Lerp(transform.position, (transform.position + new Vector3(this.xRnd, this.yRnd, 0f)), speed);
    }
}
