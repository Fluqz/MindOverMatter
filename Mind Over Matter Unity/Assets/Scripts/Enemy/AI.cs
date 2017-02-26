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

    private bool inCombat,
                    canAttack;

    private List<Ability> abilities;

    public AI(GameObject enem, Animator animator, Movement movemen, float attackRad, float terretory) {
        player = GameObject.FindWithTag("Player");
        anim = animator;

        movement = movemen;
        enemy = enem;
        attackRadius = attackRad;
        terretoryRadius = terretory;

        inCombat = false;
        canAttack = false;

    }

    public void Update() {
        inCombat = CheckTerritory(terretoryRadius);
        movement.MovementEnabled = inCombat;

        if (inCombat) {
            anim.SetBool("EnteredTerretory", inCombat);
            movement.move(getDistanceToPlayer());

            foreach(Ability a in abilities) {
                if (CheckTerritory(a.Range))
                    canAttack = true;
            }
        }

    }

    public Vector2 getDistanceToPlayer() {
        xDist = player.transform.position.x - enemy.transform.position.x;
        yDist = player.transform.position.y - enemy.transform.position.y;
        return new Vector2(xDist, yDist);
    }

    public bool CheckTerritory(float radius) {
        float disToPlayer = Vector3.Distance(enemy.transform.position, player.transform.position);
        if (disToPlayer <= radius)
            return true;
        else return false;
    }


    public List<Ability> Abilities { set { abilities = value; } }
}
