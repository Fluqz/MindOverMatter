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
    private EnemyMovement movement;

    private List<Ability> abilities = new List<Ability>();
    
    void Awake() {
        transf = GetComponent<Transform>();
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        //abilities.Add(new Teleport(anim, 0));
        abilities.Add(new EnergyShot(anim, 0));

        enemyInfo = EnemyStorage.LoadEnemyInformation(transf.name);
        movement = new EnemyMovement(enemyInfo.MovementSpeed, this.gameObject);
        ai = new AI(enemyInfo, this.gameObject, abilities, movement);


        enemyInfo.CurrentHealth = enemyInfo.MaxHealth;
        movement.MovementEnabled = true;

        healthbar.fillAmount = 1;
    }

    void Start() {
    }

    void Update() {

        if (enemyInfo.CurrentHealth <= 0)
            Death();
    }

    void FixedUpdate() {
        ai.FixedUpdate();
    }

    void OnGUI() {
    }

    void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.layer == 9)
            movement.MovementEnabled = false;
    }

    void OnCollisionExit2D(Collision2D other) {
        if (other.transform.tag == "Player")
            movement.MovementEnabled = true;

    }

    public void TakeDamage(int damage) {
        Debug.Log(damage + " on "+ gameObject.name);
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


    public EnemyMovement Movement { get { return movement; } }
    public EnemyInformation EnemyInfo { get { return enemyInfo; } }
    public List<Ability> Abilities { get { return abilities; } }

}