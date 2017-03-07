using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

public class AI {

    private Stopwatch stopwatch;

    private Vector3 basePosition;
    private GameObject player;
    private GameObject enemy;
    private float xDist, yDist, movementSpeed;

    private Rigidbody2D rigid;
    private Animator anim;

    private Movement movement;
    private EnemyAttack attack;
    private EnemyInformation enemyInfo;
    private CheckDistance checkDistance;

    private bool inCombat,
                    canAttack;

    private List<Ability> abilities;

    public AI(EnemyInformation enemyInformation, GameObject enem, List<Ability> abs, Movement movemen) {
        player = GameObject.FindWithTag("Player");
        enemyInfo = enemyInformation;
        enemy = enem;
        abilities = abs;
        movement = movemen;
        anim = enemy.GetComponent<Animator>();

        checkDistance = new CheckDistance();
        attack = new EnemyAttack(enem);
        inCombat = false;
        canAttack = false;
    }

    public void FixedUpdate() {
            

        if (!CheckTerritory(0.1f)) {
            inCombat = CheckTerritory(enemyInfo.TerretoryRadius);
            movement.Moving = inCombat;

            if (inCombat) {
                anim.SetBool("EnteredTerretory", inCombat);
                movement.Move(checkDistance.CheckDistanceAToB(enemy.transform.position, player.transform.position));

                foreach (Ability a in abilities) {
                    //if (CheckTerritory(a.Range)) {
                    if (CheckTerritory(10f) && !CheckTerritory(5f) && a.Useable) { 
                        canAttack = true;
                        attack.UseAbility(a);
                    }
                    else canAttack = false;
                }
            }
        }
        else {

        }
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
