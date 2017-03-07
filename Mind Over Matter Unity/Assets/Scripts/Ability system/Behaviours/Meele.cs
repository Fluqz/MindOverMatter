using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class Meele : AbilityBehaviour {

    private const string name = "Meele",
                            description = "A meele attack";
    private const ImpactTime impactTime = ImpactTime.End;

    private float range,
                    effectDamage,
                    hitLength;
    private GameObject prefab;

    private float timeStamp;
    private Vector2 adjustToCenter = new Vector2(.5f, 1);

    public Meele(float hitRange, float effectDmg, GameObject prefab)
        : base(new BasicObjectInformation(name, description), impactTime) {
        range = hitRange;
        effectDamage = effectDmg;
        this.prefab = prefab;
    }

    public override void Action(GameObject user, Ability ability) {
        Animator anim = user.GetComponent<Animator>();
        anim.SetTrigger("isAttacking");

        Vector2 direction = PlayerInformation.Direction;

        Vector3 swordHitPosition = new Vector3(user.transform.position.x + adjustToCenter.x, user.transform.position.y + adjustToCenter.y, 0);

        Vector3 position = new Vector3(swordHitPosition.x + (direction.x * range), swordHitPosition.y + (direction.y * range), 0);

        GameObject sword = GameObject.Instantiate(prefab, position, Quaternion.identity) as GameObject;

        SwordCollider swordCol = sword.GetComponent<SwordCollider>();
        swordCol.User = user;
        swordCol.Action(ability.Name);
    }


    private float GetDegree(Vector2 direction) {

        float degree = (float)((Mathf.Atan2(direction.x, direction.y) / Math.PI) * 180f);
        if (degree < 0) degree += 360f;

        return degree;
    }
}
