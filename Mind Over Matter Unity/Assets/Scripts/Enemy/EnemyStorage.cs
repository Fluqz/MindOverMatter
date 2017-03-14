using UnityEngine;
using System.Collections;

public static class EnemyStorage {

    private static EnemyXMLContainer enemies;


    public static EnemyXMLContainer Enemies { get { return enemies; } set { if (enemies == null) enemies = value; } }
}
