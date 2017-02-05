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

    public override void Action(GameObject player, GameObject prefab, Ability ability) {
        Vector2 dir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        float degree = GetDirection(dir);
        //Rigidbody2D bullet = GameObject.Instantiate(prefab, player.transform.position + 1.0f * player.transform.right, Quaternion.identity) as Rigidbody2D;
        Rigidbody2D bullet = GameObject.Instantiate(prefab, new Vector3(player.transform.position.x, player.transform.position.y, degree), Quaternion.identity) as Rigidbody2D;



    }

    private IEnumerator Shoot(GameObject player, GameObject bullet) {


        yield return null;
    }

    private float GetDirection(Vector2 input) {

        float degree = (float)Math.Atan2(input.y, input.x);

        return degree;
    }


}
