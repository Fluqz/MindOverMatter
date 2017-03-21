using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour {

    private Enemy enemyScript;
    private EnemyInformation enemyInfo;

	void Start () {
        enemyScript = this.gameObject.GetComponent<Enemy>();
        enemyInfo = enemyScript.EnemyInfo;
	}
	
	public void TakeDamage(int damge) {
        enemyInfo.CurrentHealth -= damge;
    }
}
