using UnityEngine;
using System.Collections;
using System;

public class Ranged : AbilityBehaviours {

    private const string name = "Ranged",
                            description = "A ranged attack";
    private const ImpactTime impactTime = ImpactTime.End;

    private float distance,
                    speed,
                    effectDamage;

    public Ranged(float dist, float travelSpeed, float effectDmg)
        : base(new BasicObjectInformation(name, description), impactTime) {
        distance = dist;
        speed = travelSpeed;
        effectDamage = effectDmg;
    }

    public override void Action(GameObject player, GameObject prefab) {
        GameObject bullet = GameObject.Instantiate(prefab, player.transform.position+1.0f*player.transform.forward, Quaternion.identity) as GameObject;

        bullet.GetComponent<Rigidbody2D>().AddForce(new Vector2(100,0));
    }

    private IEnumerator checkDistance(Vector3 playerPosition, GameObject prefab) {
       

        yield return null;
    }
    
}
