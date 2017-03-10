using UnityEngine;
using System.Collections;

public class SwordCollider : MonoBehaviour {

    private Ability ability;
    private float timeStamp;
    private bool isCollided;
    private string abilityName;

    private GameObject user;

    private Tool tool;
    
    public void Action(string name) {
        timeStamp = 0;
        isCollided = false;
        abilityName = name;
        if (user.transform.tag == "Player") {
            foreach (Ability a in PlayerInformation.Abilities) {
                if (a.Name == abilityName) {
                    ability = a;
                    break;
                }
            }
        }
        else if (user.transform.tag == "Enemy") {
            foreach (Ability a in user.GetComponent<Enemy>().Abilities) {
                if (a.Name == abilityName) {
                    ability = a;
                    break;
                }
            }
        }
        timeStamp = Time.time + ability.AbilityDuration;
        tool = new Tool();
    }
    
    void Update () {
        if (timeStamp <= Time.time)
            Destroy(gameObject);
	}

    void OnTriggerEnter2D(Collider2D other) {

        if (tool.CheckCollidersAsOneGameObejct(other))
            return;

        if (!isCollided) {
            if (other.gameObject.tag != user.transform.tag) {
                isCollided = true;
                Debug.Log(other.transform.name);
                if (other.gameObject.tag == "Player")
                    user.GetComponent<Player>().TakeDamage((int)ability.Damage);
                else if(other.gameObject.tag == "Enemy")
                    other.transform.GetComponent<Enemy>().TakeDamage((int)ability.Damage);
            }
            else if (other.gameObject.tag == user.transform.tag)
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
