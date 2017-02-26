using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class Meele : AbilityBehaviours {

    private const string name = "Meele",
                            description = "A meele attack";
    private const ImpactTime impactTime = ImpactTime.End;

    private float range,
                    effectDamage,
                    hitLength;

    private float timeStamp;
    private Vector2 adjustToCenter = new Vector2(.5f, 1);

    public Meele(float hitRange, float effectDmg)
        : base(new BasicObjectInformation(name, description), impactTime) {
        range = hitRange;
        effectDamage = effectDmg;
    }

    public override void Action(GameObject player, List<GameObject> prefab, Ability ability) {
        ability.Anim.SetTrigger("isAttacking");

        Vector2 direction = PlayerInformation.Direction;

        Vector2 degree = new Vector2(ability.Anim.GetFloat("DirectionX"), ability.Anim.GetFloat("DirectionY"));

        Vector3 swordHitPosition = new Vector3(player.transform.position.x + adjustToCenter.x, player.transform.position.y + adjustToCenter.y);

        Vector3 position = new Vector3(swordHitPosition.x + (degree.x * range), swordHitPosition.y + (degree.y * range), 0);

        GameObject sword = GameObject.Instantiate(prefab[0], position, Quaternion.identity) as GameObject;
    }


    private float GetDegree(Vector2 direction) {

        float degree = (float)((Mathf.Atan2(direction.x, direction.y) / Math.PI) * 180f);
        if (degree < 0) degree += 360f;

        return degree;
    }
}
