using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Tek {
    
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

    public Tek() {

    }

    public string Name { get; set; }
}
