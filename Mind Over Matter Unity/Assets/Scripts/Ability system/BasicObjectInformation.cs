﻿using UnityEngine;
using System.Collections;

public class BasicObjectInformation {

    private string name,
                   description;
    private Sprite icon;

    public BasicObjectInformation(string oName) {
        name = oName;
    }

    public BasicObjectInformation(string oName, string oDescription) {
        name = oName;
        description = oDescription;
    }

    public BasicObjectInformation(string oName, string oDescription, Sprite oIcon) {
        name = oName;
        description = oDescription;
        icon = oIcon; // ? needed ?
    }

    public string ObjectDescription { get { return description; } }
    public string ObjectName { get { return name; } }
    public Sprite ObjectIcon { get { return icon; } }

}
