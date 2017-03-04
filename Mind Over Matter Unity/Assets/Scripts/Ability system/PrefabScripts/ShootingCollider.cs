using UnityEngine;
using System.Collections;

public class ShootingCollider : MonoBehaviour {

    private Ability ability;
    public string abilityName;
    private bool isCollided;
    private float timeStamp;

    private GameObject user;

	
    public void Action(string name) {
        isCollided = false;
        timeStamp = 0;
        abilityName = name;
        if (user.transform.tag == "Player") {
            foreach (Ability a in PlayerInformation.Abilities) {
                if (a.AbilityInfo.ObjectName == abilityName)
                    ability = a;
            }
        }
        else if (user.transform.tag == "Enemy") {
            foreach (Ability a in user.GetComponent<Enemy>().Abilities) {
                if (a.AbilityInfo.ObjectName == abilityName)
                    ability = a;
            }
        }

        timeStamp = Time.time + ability.CastTime;
    }



	void Update () {
        if (timeStamp <= Time.time)
            Destroy(this.gameObject);
    }


    void OnTriggerEnter2D(Collider2D other) {
        
        if (other.transform.tag != user.transform.tag) {
            if (other.transform.tag == "Player")
                other.GetComponent<Player>().TakeDamage((int)ability.Damage);
            else if(other.transform.tag == "Enemy")
                other.GetComponent<Enemy>().TakeDamage((int)ability.Damage);

            Debug.Log(other.transform.name);
            if (other.transform.tag != "Environment")
                StartCoroutine(WaitAndDestroy(.2f, this.gameObject));
        }
        else if (other.transform.tag == user.transform.tag) {
            Physics2D.IgnoreCollision(user.GetComponent<Collider2D>(), other);
        }

        
    }
    void OnTriggerExit2D(Collider2D other) { }

    IEnumerator WaitAndDestroy(float wait, GameObject go) {
        yield return new WaitForSeconds(wait);
        Destroy(go);
        yield break;
    }

    public GameObject User { get { return user; } set { user = value; } }
}
