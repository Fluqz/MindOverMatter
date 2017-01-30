using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuControl : MonoBehaviour {

	void FixedUpdate () {
	    if(Input.GetKey("escape")) {
            SceneManager.LoadScene("Menu");
        }
	}

    public void ResumeGame() {
        SceneManager.LoadScene("Game");
    }

    public void ExitGame() {
        Application.Quit();
    }
}
