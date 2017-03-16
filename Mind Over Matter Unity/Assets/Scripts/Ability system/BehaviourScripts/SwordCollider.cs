using UnityEngine;
using System.Collections;

public class SwordCollider : MonoBehaviour {

    private Ability ability;
    private float timeStamp;
    private bool isCollided;
    private string abilityName;

    private GameObject user;
    
    public void Action(Ability ability) {
        this.ability = ability;
        timeStamp = 0;
        isCollided = false;
        timeStamp = Time.time + ability.AbilityDuration;
    }
    
    void Update () {
        if (timeStamp <= Time.time)
            Destroy(gameObject);
	}

    void OnTriggerEnter2D(Collider2D other) {

        if (Tools.CheckCollidersAsOneGameObejct(other))
            return;

        if (!isCollided) {
            if (!other.CompareTag(user.transform.tag)) {
                isCollided = true;
                Debug.Log(other.transform.name);
                if (other.CompareTag("Player"))
					user.GetComponent<Player>().TakeDamage((int)ability.Damage, user);
                else if(other.gameObject.CompareTag("Enemy"))
                    other.transform.GetComponent<Enemy>().TakeDamage((int)ability.Damage);
            }
            else if (other.gameObject.CompareTag(user.transform.tag))
                Physics2D.IgnoreCollision(other, user.GetComponent<Collider2D>());
        }
        else isCollided = false;
    }

    void OnDrawGizmosSelected() {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(user.transform.position, 0.47f);
    }

    public GameObject User { get { return user; } set { user = value; } }
}
