using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loader : MonoBehaviour {

    public const string enemiesPath = "XML/Enemies";

    void Awake() {
        EnemyStorage.Enemies = EnemyXMLContainer.LoadEnemyInformation(enemiesPath);
    }

}
