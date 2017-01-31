using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public static bool paused;


    void Start() {
    }

	void FixedUpdate () {
        var lastESC = false;
        if (Input.GetKeyDown("escape") && !paused && !lastESC)
            PauseGame();
        else if (Input.GetKeyDown("escape") && paused)
            ResumeGame();
        lastESC = Input.GetKey("escape");
    }



    public void ResumeGame() {
        paused = false;
        SceneManager.LoadScene("Game");
    }

    public void PauseGame() {
        paused = true;
        SceneManager.LoadScene("Pause Menu");
    }

    public void BackToMainMenu() {
        SceneManager.LoadScene("Main Menu");
    }

    public void OpenOptions() {

    }

    public void ExitGame() {
        Application.Quit();
    }
}
