﻿using UnityEngine;
using System.Collections;

public class GameControl : MonoBehaviour {

    public static GameControl control;

    public float experience;

	void Awake () {
        if(control == null) {
            DontDestroyOnLoad(gameObject);
            control = this;
        }
        else if(control != this)
            Destroy(gameObject);
	}
	
	void OnGUI () {
        GUI.Label(new Rect(10, 10, 150, 30), "Experience: " + experience);
	}
}
