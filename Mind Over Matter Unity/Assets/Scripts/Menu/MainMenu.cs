using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
        
    public void StartNewGame() {
        SceneManager.LoadScene("Game");
    }

    public void ContinueGame() {
        LoadInformation.LoadAllInformation();

    }

    public void LoadSavedGame() {
        LoadInformation.LoadAllInformation();
    }

    public void OpenOptions() {

    }

    public void ExitGame() {
        Application.Quit();
    }
}
