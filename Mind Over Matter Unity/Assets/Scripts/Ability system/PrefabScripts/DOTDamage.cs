using UnityEngine;
using System.Collections;

public class DOTDamage : MonoBehaviour {

    private Ability ability;
    public string abilityName;
    private float timeStamp, duration;

    private GameObject user, victim;


    public void Action(string name) {

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


        timeStamp = Time.time + duration;
    }

    public void MakeDamage(float damage) {
        if (victim && user) {
            if (victim.transform.tag == "Player" && user.transform.tag == "Enemy")
                victim.GetComponent<Player>().TakeDamage((int)damage);
            else if (victim.transform.tag == "Enemy" && user.transform.tag == "Player")
                victim.GetComponent<Enemy>().TakeDamage((int)damage);
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
