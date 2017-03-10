using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShootingCollider : MonoBehaviour {

    private Ability ability;
    private DamageOverTime dot;
    public string abilityName;
    private bool spawned;
    private float timeStamp;

    private GameObject user;

    private List<int> colliders;
    private Tool tool;

    void Awake() {
        spawned = false;
        tool = new Tool();
    }
	
    public void Action(string name) {
        spawned = true;
        timeStamp = 0;
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

        foreach (AbilityBehaviour ab in ability.Behaviours) {
            if (ab.AbilityBehaviorInfo.ObjectName == "Damage Over Time")
                dot = (DamageOverTime)ab;
        }

        timeStamp = Time.time + ability.AbilityDuration;
    }



	void Update () {
        if (timeStamp <= Time.time) DestroyGameObject();
    }


    void OnTriggerEnter2D(Collider2D other) {
        if (spawned) {

            if (tool.CheckCollidersAsOneGameObejct(other))
                return;

            if (other.transform.tag != user.transform.tag) {
                if (other.transform.tag == "Player" && user.transform.tag == "Enemy") {
                    other.GetComponent<Player>().TakeDamage((int)ability.Damage);
                    dot.InitDOT(user, other.gameObject, ability);
                }
                else if (other.transform.tag == "Enemy" && user.transform.tag == "Player") {
                    other.GetComponent<Enemy>().TakeDamage((int)ability.Damage);
                    dot.InitDOT(user, other.gameObject, ability);
                }


                if (other.transform.tag != "Environment")
                    StartCoroutine(WaitAndDestroy(.2f, this.gameObject));
            }
            else if (other.transform.tag == user.transform.tag) {
                Physics2D.IgnoreCollision(user.GetComponent<Collider2D>(), other);
            }
        }
    }

    void OnTriggerExit2D(Collider2D other) { }

    void DestroyGameObject() {
        colliders = null;
        Destroy(this.gameObject);
    }

    IEnumerator WaitAndDestroy(float wait, GameObject go) {
        yield return new WaitForSeconds(wait);
        Destroy(go);
        yield break;
    }

    public GameObject User { set { user = value; } }
}
