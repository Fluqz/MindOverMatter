using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    private int maxHealth,
                currentHealth;

    private bool isDead,
                    isDamaged;

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
    private EnemyBaseInformation enemyInfo;
    
    void Awake() {
        maxHealth = 7;

        transf = GetComponent<Transform>();
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        //enemyInfo = new EnemyBaseInformation();
        movement = new Movement(distance, time, transf, anim);
        ai = new AI(this.gameObject);

        //transf.transform = startingPosition;
        currentHealth = maxHealth;
        movement.MovementEnabled = true;
    }

    void Start() {
    }

    void Update() {
        ai.CheckTerritory();
        movement.move(ai.getDistanceToPlayer());

        if (currentHealth == 0)
            Death();
    }

    void FixedUpdate() {
    }

    void OnCollisionEnter2D(Collision2D other) {

    }

    private void TakeDamage(int damage) {
        isDamaged = true;
    }

    private void Attack() {
        //use ability
    }

    private void Death() {
        isDead = true;
        movement.MovementEnabled = false;
        anim.SetBool("Death", isDead);
    }


    public int MaxHealth { get { return maxHealth; } }
    public int CurrentHealth { get; set; }
    public bool IsDead { get; set; }
    public bool IsDamaged { get; set; }
}