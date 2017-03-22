using UnityEngine;
using System.Collections;

public class DOTDamage : MonoBehaviour {

    private float timeStamp, duration;

    private GameObject user, victim;


    public void Action() {
        timeStamp = 0;

        timeStamp = Time.time + duration;
    }

    public void Damage(float damage) {
        if (victim && user) {
            if (victim.CompareTag("Player") && user.transform.CompareTag("Enemy"))
                victim.GetComponent<Player>().TakeDamage((int)damage, user);
            else if (victim.CompareTag("Enemy") && user.CompareTag("Player"))
                victim.GetComponentInParent<Enemy>().TakeDamage((int)damage);
        }
    }

    void Update() {
        if (timeStamp <= Time.time)
            Destroy(this.gameObject);
    }
    
    public void DestroyGameObject(GameObject go) {
        Destroy(go);
    }

    public GameObject User { get { return user; } set { user = value; } }
    public GameObject Victim { get { return victim; } set { victim = value; } }
    public float Duration{ get { return duration; } set { duration = value; } }
}
