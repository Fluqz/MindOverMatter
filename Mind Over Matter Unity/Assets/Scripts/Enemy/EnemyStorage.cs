﻿using UnityEngine;
using System.Collections;

public static class EnemyStorage {


    public static EnemyInformation LoadEnemyInformation(string name) {

        EnemyInformation enemyInfo = new EnemyInformation(name, "2", 500, 100, 10, 2f, 10f, 4f);

        return enemyInfo;
    }

}
