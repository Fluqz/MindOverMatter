using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShootingCollider : MonoBehaviour {

    private Ability ability;
    private DamageOverTime dot;
    private bool spawned;

    private GameObject user;

    private List<int> colliders;

    void Awake() {
        spawned = false;
    }
	
    public void Action(Ability ability) {
        this.ability = ability;
        spawned = true;

        foreach (AbilityBehaviour ab in ability.Behaviours) {
            if (ab.AbilityBehaviorInfo.ObjectName == "Damage Over Time")
                dot = (DamageOverTime)ab;
        }

        StartCoroutine(WaitAndDestroy(ability.AbilityDuration, this.gameObject));
    }
    
    void OnTriggerEnter2D(Collider2D other) {
        if (spawned) {

            if (Tools.CheckCollidersAsOneGameObejct(other))
                return;

            if (!other.CompareTag(user.transform.tag)) {
                if (other.transform.CompareTag("Player") && user.CompareTag("Enemy")) {
                    other.GetComponent<Player>().TakeDamage((int)ability.Damage, user);
                    dot.InitDOT(user, other.gameObject, ability);
                }
                else if (other.CompareTag("Enemy") && user.CompareTag("Player")) {
                    other.GetComponent<Enemy>().TakeDamage((int)ability.Damage);
                    dot.InitDOT(user, other.gameObject, ability);
                }

                if (other.CompareTag("Ability")) 
                    Physics2D.IgnoreCollision(other, this.gameObject.GetComponent<BoxCollider2D>());
            }
            else if (other.CompareTag(user.transform.tag)) {
                Physics2D.IgnoreCollision(user.GetComponent<Collider2D>(), other);
            }
        }
    }

    void OnTriggerExit2D(Collider2D other) { }

    void DestroyGameObject() {
        colliders = null;
        Tools.EmptyColliderList();
        Destroy(this.gameObject);
    }

    IEnumerator WaitAndDestroy(float wait, GameObject go) {
        yield return new WaitForSeconds(wait);
        Destroy(go);
        yield break;
    }

    public GameObject User { set { user = value; } }
}
