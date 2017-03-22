using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {


    EnemyInformation enemyInfo;

    private Rigidbody2D rigid;
    protected Animator anim;
    private Transform transf;

    private AI ai;
    private EnemyMovement movement;

    private List<Ability> abilities = new List<Ability>();
    
    void Awake() {
        anim = GetComponent<Animator>();        
    }

    void Start() {
        //abilities.Add(new Teleport(anim, 0));
        abilities.Add(new EnergyShot(anim, 0));

        enemyInfo = new EnemyInformation(this.gameObject.name);
        movement = new EnemyMovement(enemyInfo, this.gameObject);
        ai = new AI(enemyInfo, this.gameObject, abilities, movement);


        enemyInfo.CurrentHealth = enemyInfo.MaxHealth;
        movement.MovementEnabled = true;
    }

    void Update() {

        if (enemyInfo.CurrentHealth <= 0)
            Death();
    }

    void FixedUpdate() {
        ai.FixedUpdate();
    }

    void OnCollisionEnter2D(Collision2D other) {
        if (other.transform.CompareTag("Player"))
            movement.MovementEnabled = false;
    }

    void OnCollisionExit2D(Collision2D other) {
        if (other.transform.CompareTag("Player"))
            movement.MovementEnabled = true;

    }

    public void TakeDamage(float damage) {
        Debug.Log(damage + " on "+ gameObject.name);
        enemyInfo.CurrentHealth -= (int)damage;
        anim.SetTrigger("isDamaged");
        this.gameObject.GetComponentInChildren<Healthbar>().ReduceHealthbar(enemyInfo.CurrentHealth, enemyInfo.MaxHealth);
    }

    public void ReduceHealthbar(float currentHealth, float MaxHealth, float minHealth) {
    }

    private void Death() {
        enemyInfo.IsDead = true;
        movement.MovementEnabled = false;
        anim.SetBool("Death", enemyInfo.IsDead);
        Destroy(this.gameObject);
    }


    public EnemyMovement Movement { get { return movement; } }
    public EnemyInformation EnemyInfo { get { return enemyInfo; } }
    public List<Ability> Abilities { get { return abilities; } }

}