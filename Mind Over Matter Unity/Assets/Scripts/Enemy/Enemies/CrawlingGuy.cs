using UnityEngine;
using System.Collections;

public class CrawlingGuy : CreateEnemy {

    private const string name = "Crawling Guy",
                    description = "A slow creature that will shoot in the ground to make a explosion.";
    private const int health = 8,
                        weight = 40,
                        baseDamage = 100,
                        degree = 3,
                        criticalStrikeChance = 30;
    private const float attackRadius = 3,
                        terretoryRadius = 10,
                        movementSpeed = 5f;

    public CrawlingGuy()
        : base(new EnemyBaseInformation(name, description, health, weight, baseDamage, attackRadius, terretoryRadius, movementSpeed, degree), criticalStrikeChance) {

    }
}
