using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Stairs : MonoBehaviour {
    
    private float slow;

    void Awake() {
        slow = 80f;
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.transform.CompareTag("Player"))
            other.GetComponentInParent<Player>().PlayerInput.Movement.UpdateVelocity(slow);
        else if (other.CompareTag("Enemy"))
            other.GetComponentInParent<Enemy>().Movement.UpdateVelocity(slow);
    }

    void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("Player"))
            other.GetComponentInParent<Player>().PlayerInput.Movement.UpdateVelocity(100);
        else if (other.CompareTag("Enemy"))
            other.GetComponentInParent<Enemy>().Movement.UpdateVelocity(100);
    }
}
