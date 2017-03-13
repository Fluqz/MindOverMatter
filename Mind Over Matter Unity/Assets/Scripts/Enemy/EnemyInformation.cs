using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyInformation {

    private string name,
                    description;
    private int maxHealth,
                currentHealth,
                weight,
                damage,
                degree;
    private float attackRadius,
                    terretoryRadius,
                    movementSpeed;
    private bool isDead,
                    isDamaged;
    private Vector2 direcion;
    
    public EnemyInformation(string eName, string eDescription, int mHealth, int eWeight, int eBaseDamage, float attackRad, float terretory, float speed) {
        this.name = eName;
        this.description = eDescription;
        this.maxHealth = mHealth;
        this.weight = eWeight;
        this.damage = eBaseDamage;
        this.attackRadius = attackRad;
        this.terretoryRadius = terretory;
        this.movementSpeed = speed;
        
        this.currentHealth = this.maxHealth;
        this.isDead = false;
        this.isDamaged = false;
    }


    public string Name { get {return name; } set { name = value; } }
    public string Description { get { return description; } set { name = description; } }
    public int MaxHealth { get { return maxHealth; } set { maxHealth = value; } }
    public int CurrentHealth { get { return currentHealth; } set { currentHealth = value; } }
    public int Weight { get { return weight; } set { weight = value; } }
    public int Damage { get { return damage; } set { damage = value; } }
    public int Degree { get { return degree; } set { degree = value; } }
    public float AttackRadius { get { return attackRadius; } set { attackRadius = value; } }
    public float TerretoryRadius { get { return terretoryRadius; } set { terretoryRadius = value; } }
    public float MovementSpeed { get { return movementSpeed; } set { movementSpeed = value; } }
    public bool IsDead { get { return isDead; } set { isDead = value; } }
    public bool IsDamaged { get { return isDamaged; } set { isDamaged = value; } }
    public Vector2 Direction{ get { return direcion; } set { direcion = value; } }
}
