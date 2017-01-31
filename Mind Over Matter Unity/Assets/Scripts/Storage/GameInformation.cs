using UnityEngine;
using System.Collections;

public class GameInformation : MonoBehaviour {

	void Awake () {
        DontDestroyOnLoad(transform.gameObject);
	}

    public static string PlayerName { get; set; }
    public static int PlayerLevel { get; set; }

}
