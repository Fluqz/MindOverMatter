using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {

    public Image healthbar;

    EnemyInformation enemyInfo;

    private Rigidbody2D rigid;
    protected Animator anim;
    private Transform transf;

    private Vector3 startingPosition;
    private Vector2 input;

    private AI ai;
    private Movement movement;

    private List<Ability> abilities = new List<Ability>();
    
    void Awake() {
        transf = GetComponent<Transform>();
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        enemyInfo = EnemyStorage.LoadEnemyInformation(transf.name);
        movement = new Movement(enemyInfo.Distance, enemyInfo.Time, transf, anim);
        ai = new AI(enemyInfo, this.gameObject, anim, movement, enemyInfo.AttackRadius, enemyInfo.TerretoryRadius);

        abilities.Add(new Teleport(anim));
        ai.Abilities = abilities;

        enemyInfo.CurrentHealth = enemyInfo.MaxHealth;
        movement.MovementEnabled = true;

        healthbar.fillAmount = 1;
    }

    void Start() {
    }

    void Update() {
        ai.Update();
        

        if (enemyInfo.CurrentHealth <= 0)
            Death();
    }

    void FixedUpdate() {
    }

    void OnGUI() {
    }

    void OnCollisionEnter2D(Collision2D other) {

    }

    public void TakeDamage(int damage) {
        enemyInfo.CurrentHealth -= damage;
        anim.SetTrigger("isDamaged");
        ReduceHealthbar(enemyInfo.CurrentHealth, enemyInfo.MaxHealth, 0);
    }

    public void ReduceHealthbar(float currentHealth, float MaxHealth, float minHealth) {
        healthbar.fillAmount = ((currentHealth - minHealth) * (1 - 0) / (MaxHealth - minHealth) + 0);
    }

    private void Death() {
        enemyInfo.IsDead = true;
        movement.MovementEnabled = false;
        anim.SetBool("Death", enemyInfo.IsDead);
        Destroy(this.gameObject);
    }


    public Movement Movement { get { return movement; } }
    public EnemyInformation EnemyInfo { get { return enemyInfo; } }

}