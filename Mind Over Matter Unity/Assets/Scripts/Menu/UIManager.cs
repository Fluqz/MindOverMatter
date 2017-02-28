using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {

    public static bool paused;
    private Animator anim;
    public GameObject pauseMenu;

    void Start() {
        anim = pauseMenu.GetComponentInChildren<Animator>();
        paused = false;
        pauseMenu.SetActive(false);
    }

    void FixedUpdate() {
        if (Input.GetKeyDown("escape")) {
            if (paused)
                ResumeGame();
            else PauseGame();
        }
    }

    public void ResumeGame() {
        paused = false;
        pauseMenu.SetActive(paused);
        anim.SetBool("Paused", paused);
    }

    public void PauseGame() {
        paused = true;
        pauseMenu.SetActive(true);
        anim.SetBool("Paused", true);
    }

    public void BackToMainMenu() {
    }

    public void OpenOptions() {

    }

    public void ExitGame() {
        Application.Quit();
    }
}
