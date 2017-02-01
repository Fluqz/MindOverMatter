using UnityEngine;
using System.Collections;

public class AI {

    private Vector3 basePosition;
    private GameObject player;
    private GameObject enemy;
    private float xDist, yDist, distance = 3, time = 2;

    private Rigidbody2D rigid;
    private Animator anim;

    private float terretoryRadius = 20,
                    attackRadius = 2;
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

    public void CheckTerritory() {
        if (Vector3.Distance(enemy.transform.position, player.transform.position) <= terretoryRadius) {
            entered = true;
            if (Vector3.Distance(enemy.transform.position, player.transform.position) <= attackRadius)
                canAttack = true;
            else canAttack = false;
        }
        else entered = false;
        anim.SetBool("enteredTerretory", entered);
    }

}
