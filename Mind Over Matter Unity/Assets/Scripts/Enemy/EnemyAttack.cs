using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour {

    private float attackDamage = 1;
    private float criticalStrikeChance;

	void Start () {
	
	}
	
	void Update () {
	
	}
    

    bool CalculateCriticalStrike(float critChance) {
        float random = Random.Range(0, 100);
        if (random < critChance)
            return true;
        else return false;
    }
}
