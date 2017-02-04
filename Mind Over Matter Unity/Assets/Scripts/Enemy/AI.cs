using UnityEngine;
using System.Collections;

public class AI {

    private Vector3 basePosition;
    private GameObject player;
    private GameObject enemy;
    private float xDist, yDist, distance = 3f, time = 2f;

    private Rigidbody2D rigid;
    private Animator anim;

    private float terretoryRadius = 12f,
                    attackRadius = 2f;
    private bool entered,
                    canAttack;

    public AI(GameObject enem) {
        player = GameObject.FindWithTag("Player");
        enemy = enem;
        anim = enemy.GetComponent<Animator>();

        entered = false;
        canAttack = false;
    }
    
    public Vector2 getDistanceToPlayer() {
        xDist = player.transform.position.x - enemy.transform.position.x;
        yDist = player.transform.position.y - enemy.transform.position.y;
        return new Vector2(xDist, yDist);
    }

    public void CheckTerritory(Movement movement) {
        float disToPlayer = Vector3.Distance(enemy.transform.position, player.transform.position);
        if (disToPlayer <= terretoryRadius) {
            entered = true;
            anim.SetBool("enteredTerretory", entered);
            if (disToPlayer <= attackRadius) {
                canAttack = true;
            }
            else canAttack = false;
            movement.MovementEnabled = !canAttack;
            return;
        }
        else entered = false;

        movement.MovementEnabled = false;
    }

}
