using UnityEngine;
using System.Collections;

public class BasicObjectInformation {

    private string name,
                   description;

    public BasicObjectInformation(string oName) {
        name = oName;
    }

    public BasicObjectInformation(string oName, string oDescription) {
        name = oName;
        description = oDescription;
    }

    public string ObjectDescription { get { return description; } }
    public string ObjectName { get { return name; } }

}
