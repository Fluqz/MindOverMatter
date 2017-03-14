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

    private bool inCombat,
                    canAttack;

    private Vector2 destination;
    private float timeStamp, checkRate;

    private List<Ability> abilities;

    public AI(EnemyInformation enemyInformation, GameObject enem, List<Ability> abs, EnemyMovement movemen) {
        player = GameObject.FindWithTag("Player");
        enemyInfo = enemyInformation;
        enemy = enem;
        abilities = abs;
        movement = movemen;
        anim = enemy.GetComponent<Animator>();

        attack = new EnemyAttack(enem);
        inCombat = false;
        canAttack = false;
        checkRate = .6f;
        timeStamp = Time.time + checkRate;
    }

    public void FixedUpdate() {
        if (inCombat) {
            movement.Move(Tools.CheckDistanceAToB(enemy.transform.position, PlayerInformation.Position), destination);
            enemyInfo.Direction = movement.Direction;

        }
    }

    public void Update() {

        if (timeStamp < Time.time) {
            destination = PlayerInformation.Position;
            timeStamp = Time.time + checkRate;
        }

        if (!CheckTerritory(0.5f)) {
            inCombat = CheckTerritory(enemyInfo.TerretoryRadius);
            movement.IsWalking = inCombat;

            if (inCombat) {
                anim.SetBool("EnteredTerretory", inCombat);

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
