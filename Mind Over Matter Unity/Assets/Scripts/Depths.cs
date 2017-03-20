using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Depths : MonoBehaviour {
    	
	void Start () {
        if(this.gameObject.GetComponent<Rigidbody2D>())
            InvokeRepeating("UpdateDepths", 0, 0.1f);
	}

    void UpdateDepths() {
        this.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.y);
    }
}
