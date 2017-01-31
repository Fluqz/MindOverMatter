using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Tek : Enemy {
    
    private const string name = "Tek",
                    description = "A fast fighter.";
    private const int health = 10,
                        weight = 60,
                        baseDamage = 2,
                        degree = 5,
                        criticalStrikeChance = 20;
    private const float attackRadius = 2,
                        terretoryRadius = 15,
                        movementSpeed = 10f;

    public Tek() 
        :base(new EnemyBaseInformation(name, description, health, weight, baseDamage, attackRadius, terretoryRadius, movementSpeed, degree), criticalStrikeChance) {

        this.EnemyAbilities.Add(new EnergyShot());
    }

    public string Name { get; set; }
}
