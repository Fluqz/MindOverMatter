using UnityEngine;
using System.Collections;

public class InitEnemy : MonoBehaviour {

    private GameObject enemy;

	void Start () {
        enemy = gameObject;
        string className = enemy.transform.name.ToString();
        Tek enemyType = (Tek)System.Reflection.Assembly.GetExecutingAssembly().CreateInstance(className);
        Debug.Log(enemyType);


    }
	
	void Update () {
	
	}
}
