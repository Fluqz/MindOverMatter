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

    private EnemyMovement movement;
    private EnemyAttack attack;
    private EnemyInformation enemyInfo;
    private Tool checkDistance;

    private bool inCombat,
                    canAttack;

    private List<Ability> abilities;

    public AI(EnemyInformation enemyInformation, GameObject enem, List<Ability> abs, EnemyMovement movemen) {
        player = GameObject.FindWithTag("Player");
        enemyInfo = enemyInformation;
        enemy = enem;
        abilities = abs;
        movement = movemen;
        anim = enemy.GetComponent<Animator>();

        checkDistance = new Tool();
        attack = new EnemyAttack(enem);
        inCombat = false;
        canAttack = false;
    }

    public void FixedUpdate() {
            

        if (!CheckTerritory(0.1f)) {
            inCombat = CheckTerritory(enemyInfo.TerretoryRadius);
            movement.IsWalking = inCombat;

            if (inCombat) {
                anim.SetBool("EnteredTerretory", inCombat);
                movement.Move(checkDistance.CheckDistanceAToB(enemy.transform.position, PlayerInformation.Position), PlayerInformation.Position);


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
        float disToPlayer = Vector3.Distance(enemy.transform.position, PlayerInformation.Position);
        UnityEngine.Debug.DrawLine(enemy.transform.position, PlayerInformation.Position, Color.cyan, 0, false);
        if (disToPlayer <= radius)
            return true;
        return false;
    }


    public List<Ability> Abilities { set { abilities = value; } }
}
