using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

public class AI {

    private Stopwatch stopwatch;

    private Vector3 basePosition;
    private GameObject player;
    private GameObject enemy;
    private float xDist, yDist, distance = 3f, time = 2f;
    private float terretoryRadius, attackRadius;

    private Rigidbody2D rigid;
    private Animator anim;

    private Movement movement;
    private EnemyInformation enemyInfo;

    private bool inCombat,
                    canAttack,
                    isAttacking;

    private List<Ability> abilities;

    public AI(EnemyInformation enemyInformation, GameObject enem, Animator animator, Movement movemen, float attackRad, float terretory) {
        player = GameObject.FindWithTag("Player");
        enemyInfo = enemyInformation;
        enemy = enem;
        anim = animator;

        movement = movemen;
        attackRadius = attackRad;
        terretoryRadius = terretory;

        inCombat = false;
        canAttack = false;
        isAttacking = false;
    }

    public void Update() {
            

        if (!CheckTerritory(0.1f)) {
            inCombat = CheckTerritory(terretoryRadius);
            movement.MovementEnabled = inCombat;

            if (inCombat) {
                anim.SetBool("EnteredTerretory", inCombat);
                movement.move(getDistanceToPlayer());

                foreach (Ability a in abilities) {
                    //if (CheckTerritory(a.Range)) {
                    if (CheckTerritory(2)) { 
                        canAttack = true;
                            Job.make(Stopwatch(1f));
                    }
                    else canAttack = false;
                }
            }
        }
        else {

        }
    }
    float t = 0;
    public IEnumerator Stopwatch(float wait) {
        isAttacking = true;
         t += Time.deltaTime;

        if (t >= wait) {
            Attack();
            t = 0;
        }

        yield break;
    }

    void Attack() {
        player.GetComponent<Player>().TakeDamage(enemyInfo.Damage);
        isAttacking = false;
    }

    public Vector2 getDistanceToPlayer() {
        xDist = player.transform.position.x - enemy.transform.position.x;
        yDist = player.transform.position.y - enemy.transform.position.y;
        return new Vector2(xDist, yDist);
    }

    public bool CheckTerritory(float radius) {
        float disToPlayer = Vector3.Distance(enemy.transform.position, player.transform.position);
        UnityEngine.Debug.DrawLine(enemy.transform.position, player.transform.position, Color.cyan, 0, false);
        if (disToPlayer <= radius)
            return true;
        return false;
    }


    public List<Ability> Abilities { set { abilities = value; } }
}
