using UnityEngine;
using System.Collections;

public class EnemyAI {

    private Vector3 basePosition;
    private GameObject player;
    private GameObject[] enemies;
    private Vector3 playerPosition;
    private float xDif, yDif;
    public float speed;
    private string name;

    private Rigidbody2D rigid;
    private Animator anim;
    private Transform transf;

    private float terretoryRadius = 20,
                    attackRadius = 2;
    private bool entered,
                    canAttack;

    public EnemyAI(string name, float speed, float terretory, float attackRad) {
        this.name = name;
        this.speed = speed;
        this.terretoryRadius = terretory;
        this.attackRadius = attackRad;

        player = GameObject.FindWithTag("Player");
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject go in enemies) {
            if (go.transform.name == name)
                transf = go.transform;
        }
        basePosition = transf.position;
        entered = false;
        canAttack = false;
    }
    	
	void Update () {
        if (entered && !canAttack) {
            Movement();
        }
    }

    void FixedUpdate() {
        CheckTerritory();
    }

    void Movement() {
        xDif = player.transform.position.x - this.transf.position.x;
        yDif = player.transform.position.y - this.transf.position.y;

        this.transf.Translate(new Vector3(xDif, yDif, 0).normalized * speed, Space.World);
    }

    void CheckTerritory() {
        if (Vector3.Distance(this.transf.position, player.transform.position) <= terretoryRadius) {
            entered = true;
            if (Vector3.Distance(this.transf.position, player.transform.position) <= attackRadius)
                canAttack = true;
            else canAttack = false;
        }
        else entered = false;
        anim.SetBool("enteredTerretory", entered);
    }

}
