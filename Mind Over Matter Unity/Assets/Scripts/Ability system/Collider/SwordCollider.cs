using UnityEngine;
using System.Collections;

public class SwordCollider : MonoBehaviour {

    public CircleCollider2D coller;

    private float timeStamp;

    private Ability ability;

    // Use this for initialization
    void Start() {
        foreach (Ability a in PlayerInformation.Abilities) {
            if (a.AbilityInfo.ObjectName == "Sword Thrust")
                ability = a;
        }
        timeStamp = Time.time + ability.CastTime;
    }
	
	// Update is called once per frame
	void Update () {
        if (timeStamp <= Time.time)
            Destroy(gameObject);
	}

    void OnTriggerEnter2D(Collider2D other) {
        Debug.Log(other.transform.tag);
        if(other.gameObject.tag == "Player") {
            Physics2D.IgnoreCollision(other.gameObject.GetComponent<Collider2D>(), this.coller);
        }
        else {
            if(other.gameObject.tag == "Enemy") {
                Debug.Log("Hit Enemy");
                other.transform.GetComponent<Enemy>().TakeDamage((int)ability.Damage);
            }
        }
    }
}
