using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    CreatePlayer createPlayer;
    
    public void StartNewGame() {
        SaveInformation.SaveAllInformation();
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
