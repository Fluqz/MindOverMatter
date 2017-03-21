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

    private Vector2 input;
    private float timeStamp, checkRate;

    private List<Ability> abilities;

    private AIState state;
    public enum AIState {
        IDLE,
        ISWALKING,
        ATTACKING,
        DAMAGED,
        BLEEDING,
        RUNNING,
        DEFENDING
    }

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
        state = AIState.IDLE;
    }

    public void FixedUpdate() {
        if (inCombat) {
            movement.Move(input);
            enemyInfo.Direction = movement.Direction;

        }
    }

    public void Update() {
        if (timeStamp < Time.time) {
            timeStamp = Time.time + checkRate;
        }

        if (AIState.IDLE == state) {
            justMoveIt();
        }







        

        /*
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
            }*/
    }




    public Vector2 RayCastToPlayer() {
        int layer = LayerMask.NameToLayer(player.tag);
        RaycastHit2D hit = Physics2D.Raycast(enemy.transform.position, enemyInfo.Direction, enemyInfo.TerretoryRadius, 1 << layer);
        if (hit.collider != null) {
            return Tools.CheckDistanceAToB(enemy.transform.position, hit.collider.transform.position);
        }
        return Vector2.zero;
    }

    public bool CheckTerritory(float radius) {
        float disToPlayer = Vector3.Distance(enemy.transform.position, PlayerInformation.Position);
        UnityEngine.Debug.DrawLine(enemy.transform.position, PlayerInformation.Position, Color.cyan, 0, false);
        if (disToPlayer <= radius)
            return true;
        return false;
    }

    public void justMoveIt() {
        float rndDistance = Random.Range(0, 5);
        Vector2 rndDirection = new Vector2(Random.Range(-1, 1), Random.Range(-1, 1));
        input = Tools.CheckDistanceAToB(enemy.transform.position, PlayerInformation.Position);

        movement.Move(input);
    }

    public List<Ability> Abilities { set { abilities = value; } }
}
