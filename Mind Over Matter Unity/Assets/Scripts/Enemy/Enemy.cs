using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Enemy : MonoBehaviour {

    private int maxHealth,
                currentHealth;

    private bool isDead,
                    isDamaged;
    private float terretoryRadius = 12f,
                    attackRadius = 2f;

    // Movement speed
    private float distance = 10f;
    private float time = 5f;

    private Rigidbody2D rigid;
    protected Animator anim;
    private Transform transf;

    private Vector3 startingPosition;
    private Vector2 input;

    private AI ai;
    private Movement movement;

    private List<Ability> abilities = new List<Ability>();
    
    void InitEnemy() {
        abilities.Add(new Teleport(anim));

        ai.Abilities = abilities;
    }

    void Awake() {
        maxHealth = 200;

        transf = GetComponent<Transform>();
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        //enemyInfo = new EnemyBaseInformation();
        movement = new Movement(distance, time, transf, anim);

        ai = new AI(this.gameObject, anim, movement, attackRadius, terretoryRadius);
        InitEnemy();
        //transf.transform = startingPosition;
        currentHealth = maxHealth;
        movement.MovementEnabled = true;
    }

    void Start() {
    }

    void Update() {
        ai.Update();
        

        if (currentHealth <= 0)
            Death();
    }

    void FixedUpdate() {
    }

    void OnGUI() {
    }

    void OnCollisionEnter2D(Collision2D other) {

    }

    public void TakeDamage(int damage) {
        currentHealth -= damage;
        isDamaged = true;
    }

    private void Attack() {
        //use ability
    }

    private void Death() {
        isDead = true;
        movement.MovementEnabled = false;
        anim.SetBool("Death", isDead);
        Destroy(this.gameObject);
    }


    public int MaxHealth { get { return maxHealth; } }
    public int CurrentHealth { get; set; }
    public bool IsDead { get; set; }
    public bool IsDamaged { get; set; }
}