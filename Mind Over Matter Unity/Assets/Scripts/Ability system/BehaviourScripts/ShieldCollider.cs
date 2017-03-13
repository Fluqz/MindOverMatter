using UnityEngine;
using System.Collections;

public class ShieldCollider : MonoBehaviour {

    private bool spawned;
    private GameObject user;
    private Ability ability;
    private AbilityBehaviour abilityBehaviour;


    public void Action(Ability ability) {
        this.ability = ability;
        spawned = true;
        
        abilityBehaviour = FindAbility.GetAbilityBehaviour("Protection", ability);

        StartCoroutine(DestroyAfterSeconds(ability.AbilityDuration));
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.transform.CompareTag("Ability")) {
            Destroy(other.gameObject);
        }
    }

    IEnumerator DestroyAfterSeconds(float seconds) {
        yield return new WaitForSeconds(seconds);
        DestroyGO(this.gameObject);
        yield break;
    }

    public void DestroyGO(GameObject go) {
        
        Destroy(go);
    }

    public GameObject User { set { user = value; } }
    public Ability Ability { set { ability = value; } }
}
