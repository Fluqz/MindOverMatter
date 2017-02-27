using UnityEngine;
using System.Collections;

public class PainfulCreature {

    private const string name = "Painful Creature",
                       description = "A slow but nasty creature.";
    private const int health = 15,
                weight = 100,
                baseDamage = 2,
                degree = 4,
                criticalStrikeChance = 10;
    private const float attackRadius = 1f,
                        terretoryRadius = 14f,
                        movementSpeed = 10f;

    public PainfulCreature() {

        //this.EnemyAbilities.Add(new Teleport());
    }
}
