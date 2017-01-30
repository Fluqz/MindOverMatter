using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Enemy {

    private int criticalStrikeChance;
    private EnemyBaseInformation enemyInfo;
    private List<Ability> abilities;
    private EnemyAI ai;

    public Enemy(EnemyBaseInformation enemyBaseInfo) {
        this.enemyInfo = enemyBaseInfo;
        this.ai = new EnemyAI(enemyBaseInfo.MovementSpeed, enemyBaseInfo.TerretoryRadius, enemyBaseInfo.AttackRadius);
    }

    public Enemy(EnemyBaseInformation enemyBaseInfo, int eCriticalStrikeChance) {
        this.enemyInfo = enemyBaseInfo;
        this.criticalStrikeChance = eCriticalStrikeChance;
        this.ai = new EnemyAI(enemyBaseInfo.MovementSpeed, enemyBaseInfo.TerretoryRadius, enemyBaseInfo.AttackRadius);
    }


    public EnemyBaseInformation EnemyInformation { get; set; }
    public int CriticalStrikeChance { get { return criticalStrikeChance; } set { criticalStrikeChance = value; } }
    public List<Ability> EnemyAbilities { get { return abilities; } set { abilities = value; } }
}
