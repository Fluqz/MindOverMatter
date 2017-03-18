using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System;

public class UIManager : MonoBehaviour {

    public static bool paused;
    private Animator anim;
    public GameObject pauseMenu;
    private GameObject player;
    PlayerInput playerInput;

    void Start() {
        player = GameObject.FindWithTag("Player");
        playerInput = player.GetComponent<Player>().PlayerInput;
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
        anim.SetBool("Paused", false);

        StartCoroutine(WaitForSeconds(1.7f, WaitForAnimation));
    }

    public void WaitForAnimation() {
        pauseMenu.SetActive(false);
        playerInput.InGame = true;
    }

    public IEnumerator WaitForSeconds(float wait, Action method) {
        yield return new WaitForSeconds(wait);
        method();
    }

    public void PauseGame() {
        paused = true;
        playerInput.InGame = false;
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
