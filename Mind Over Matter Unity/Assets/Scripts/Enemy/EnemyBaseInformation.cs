using UnityEngine;
using System.Collections;

public class EnemyBaseInformation {
    private string name,
                    description;
    private int health,
                weight,
                baseDamage,
                degree;
    private float attackRadius,
                    terretoryRadius,
                    movementSpeed;

    public EnemyBaseInformation(string eName, string eDescription, int eHealth, int eWeight, int eBaseDamage, float attackRad, float terretory, float moveSpeed, int eDegree) {
        this.name = eName;
        this.description = eDescription;
        this.health = eHealth;
        this.weight = eWeight;
        this.baseDamage = eBaseDamage;
        this.degree = eDegree;
        this.attackRadius = attackRad;
        this.terretoryRadius = terretory;
        this.movementSpeed = moveSpeed;
    }

    public string Name { get; set; }
    public string Description { get; set; }
    public int Health { get; set; }
    public int Weight { get; set; }
    public int BaseDamage { get; set; }
    public int Degree { get; set; }
    public int AttackRadius { get; set; }
    public int TerretoryRadius { get; set; }
    public int MovementSpeed { get; set; }
}
