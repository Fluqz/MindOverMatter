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

    public string Name { get {return name; } set { name = value; } }
    public string Description { get { return description; } set { name = description; } }
    public int Health { get { return health; } set { health = value; } }
    public int Weight { get { return weight; } set { weight = value; } }
    public int BaseDamage { get { return baseDamage; } set { baseDamage = value; } }
    public int Degree { get { return degree; } set { degree = value; } }
    public float AttackRadius { get { return attackRadius; } set { attackRadius = value; } }
    public float TerretoryRadius { get { return terretoryRadius; } set { terretoryRadius = value; } }
    public float MovementSpeed { get { return movementSpeed; } set { movementSpeed = value; } }
}
