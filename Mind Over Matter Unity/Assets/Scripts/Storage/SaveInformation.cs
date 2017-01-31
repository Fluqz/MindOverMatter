using UnityEngine;
using System.Collections;

public class SaveInformation {

    public static void SaveAllInformation() {
        PlayerPrefs.SetInt("PLAYERLEVEL", GameInformation.PlayerLevel);
        PlayerPrefs.SetString("PLAYERNAME", GameInformation.PlayerName);

    }
}
