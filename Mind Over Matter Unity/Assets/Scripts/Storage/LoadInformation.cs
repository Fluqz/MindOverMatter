using UnityEngine;
using System.Collections;

public class LoadInformation {

    public static void LoadAllInformation() {
        GameInformation.PlayerLevel = PlayerPrefs.GetInt(PlayerPrefs.GetString("PLAYERLEVEL"));
        GameInformation.PlayerName = PlayerPrefs.GetString(PlayerPrefs.GetString("PLAYERNAME"));
    }
}
