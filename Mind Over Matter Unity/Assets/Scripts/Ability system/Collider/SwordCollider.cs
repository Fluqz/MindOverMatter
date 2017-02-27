using UnityEngine;
using System.Collections;

public class SwordCollider : MonoBehaviour {

    public CircleCollider2D coller;

    private float timeStamp;

    private Ability ability;

    private bool hit;

    // Use this for initialization
    void Start() {
        hit = false;
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
        if (!hit) {
            if (other.gameObject.tag == "Enemy") {
                hit = true;
                Debug.Log(other.transform.name);
                other.transform.GetComponent<Enemy>().TakeDamage((int)ability.Damage);
            }
            else if (other.gameObject.tag == "Player")
                Physics2D.IgnoreCollision(other, this.coller);
        }
        else hit = false;
    }

    void OnDrawGizmosSelected() {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(coller.transform.position, 0.47f);
    }
}
