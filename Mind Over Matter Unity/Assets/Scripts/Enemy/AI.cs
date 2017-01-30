using UnityEngine;
using System.Collections;

public class AI : MonoBehaviour {

    private Vector3 basePosition;
    private GameObject player;
    private Vector3 playerPosition;
    private float xDif, yDif, distance = 3, time = 2;

    private Rigidbody2D rigid;
    private Animator anim;

    private float terretoryRadius = 20,
                    attackRadius = 2;
    private bool entered,
                    canAttack;

    void Awake() {
        anim = GetComponent<Animator>();
        player = GameObject.FindWithTag("Player");
        basePosition = transform.position;
        entered = false;
        canAttack = false;
    }

    void Update() {
        if (entered && !canAttack) {
            Movement();
        }
    }

    void FixedUpdate() {
        CheckTerritory();
    }

    void Movement() {
        xDif = player.transform.position.x - this.transform.position.x;
        yDif = player.transform.position.y - this.transform.position.y;

        this.transform.Translate(new Vector3(xDif, yDif, 0).normalized * Time.deltaTime * (distance / time), Space.World);
    }

    void CheckTerritory() {
        if (Vector3.Distance(this.transform.position, player.transform.position) <= terretoryRadius) {
            entered = true;
            if (Vector3.Distance(this.transform.position, player.transform.position) <= attackRadius)
                canAttack = true;
            else canAttack = false;
        }
        else entered = false;
        anim.SetBool("enteredTerretory", entered);
    }

}
