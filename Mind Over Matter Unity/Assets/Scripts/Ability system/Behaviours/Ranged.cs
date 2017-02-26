using UnityEngine;
using System.Collections;
using System.Collections.Generic;
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

    public override void Action(GameObject player, List<GameObject> prefab, Ability ability) {
        Vector2 direction = PlayerInformation.Direction;

        float degree = GetDegree(direction);

        Rigidbody2D bullet = GameObject.Instantiate(prefab[0], player.transform.position, Quaternion.Euler(0, 0, degree)) as Rigidbody2D;
    
        Job.make(Shoot(direction, bullet));
    }

    private IEnumerator Shoot(Vector2 direction, Rigidbody2D bullet) {


        yield return null;
    }

    private float GetDegree(Vector2 direction) {

        float degree = (float)((Mathf.Atan2(direction.x, direction.y) / Math.PI) * 180f);
        if (degree < 0) degree += 360f;

        return degree;
    }
}
