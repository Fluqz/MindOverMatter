using UnityEngine;
using System.Collections;

public class Stairs : MonoBehaviour {

    private Enemy enemy;

    private float slow;
    private bool entered, exited;

    void Awake() {
        slow = 8f;
        entered = false;
        exited = true;
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (!entered && exited) {
            entered = true;
            exited = false;
            Debug.Log("hi");
            if (other.transform.tag == "Player") {
                other.GetComponent<Player>().PlayerInput.Movement.UpdateVelocity(PlayerInformation.Distance - slow);
            }
            else if (other.transform.tag == "Enemy") {
                enemy = other.GetComponent<Enemy>();
                enemy.Movement.UpdateVelocity(enemy.EnemyInfo.Distance - slow);
            }
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if (entered && !exited) {
            entered = false;
            exited = true;
            Debug.Log("bye");
            if (other.transform.tag == "Player") {
                other.GetComponent<Player>().PlayerInput.Movement.UpdateVelocity(PlayerInformation.Distance + slow);
            }
            else if (other.transform.tag == "Enemy") {
                enemy = other.GetComponent<Enemy>();
                enemy.Movement.UpdateVelocity(enemy.EnemyInfo.Distance + slow);
            }
        }
    }
}
