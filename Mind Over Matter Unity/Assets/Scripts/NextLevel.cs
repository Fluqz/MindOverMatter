using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour {

    public GameObject player;
    private BoxCollider2D col;
    private bool exit;

	void Start () {
        col = GetComponent<BoxCollider2D>();
        exit = false;
	}
	
    void Update() {
        if (Input.GetKey("escape") && exit) {
            SceneManager.LoadScene("Menu");
        }
    }

	void OnCollisionEnter2D (Collision2D player) {
        exit = true;
	}
    void OnCollisionExit2D(Collision2D player) {
        exit = false;
    }
}
