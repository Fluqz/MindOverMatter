using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Stairs : MonoBehaviour {
    
    private float slow;

    void Awake() {
        slow = 80f;
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.transform.tag == "Player")
            other.GetComponent<Player>().PlayerInput.Movement.UpdateVelocity(slow);
        else if (other.transform.tag == "Enemy")
            other.GetComponent<Enemy>().Movement.UpdateVelocity(slow);
    }

    void OnTriggerExit2D(Collider2D other) {
        if (other.transform.tag == "Player")
            other.GetComponent<Player>().PlayerInput.Movement.UpdateVelocity(100);
        else if (other.transform.tag == "Enemy")
            other.GetComponent<Enemy>().Movement.UpdateVelocity(100);
    }
}
