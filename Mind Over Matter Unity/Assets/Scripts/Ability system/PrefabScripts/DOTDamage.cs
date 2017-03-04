using UnityEngine;
using System.Collections;

public class DOTDamage : MonoBehaviour {

    private Ability ability;
    public string abilityName;
    private float timeStamp, ticks;

    private GameObject user;


    public void Action(string name) {
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



    void Update() {
        if (timeStamp <= Time.time)
            Destroy(gameObject);
        else {

        }
    }
    
    public GameObject User { get { return user; } set { user = value; } }
}
