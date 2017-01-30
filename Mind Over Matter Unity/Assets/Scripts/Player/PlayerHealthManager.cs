using UnityEngine;
using System.Collections;

public class PlayerHealthManager : MonoBehaviour {

    public int health = 10;
    public int currentHealth;

    private bool isDead,
                 isDamaged;

    void Start () {
        currentHealth = health;
        isDead = false;
        isDamaged = false;
    }

	void Update () {

    }

    public void TakeDamage(int damage) {
        isDamaged = true;

        currentHealth -= damage;

        if (currentHealth <= 0 && !isDead)
            Death();
    }

    void Death() {
        isDead = true;
    }
}
