using UnityEngine;
using System.Collections;
using System;

public class Range : AbilityBehaviour {

    private const string name = "Ranged",
                            description = "A ranged attack";
    private const ImpactTime impactTime = ImpactTime.End;

    private float distance,
                    speed,
                    effectDamage;

    private GameObject prefab;


    public Range(float dist, float travelSpeed, float effectDmg, GameObject prefab)
        : base(new BasicObjectInformation(name, description), impactTime) {
        distance = dist;
        speed = travelSpeed;
        effectDamage = effectDmg;
        this.prefab = prefab;
    }

    public override void Action(GameObject user, Ability ability) {
        Animator anim = user.GetComponent<Animator>();
        Vector2 direction = new Vector2(anim.GetFloat("DirectionX"), anim.GetFloat("DirectionY"));
        //Sprite rotation
        Quaternion rotation = Quaternion.Euler(0, 0, Mathf.Atan2(direction.y*(-1), direction.x*(-1)) * Mathf.Rad2Deg);
        //Plaeyrposition adjusted in middle
        Vector3 userPos = new Vector3(user.transform.position.x, user.transform.position.y, 0);
        // instantiate bullet
        GameObject bullet = GameObject.Instantiate(prefab, userPos, rotation) as GameObject;
        bullet.transform.parent = user.transform;
        // pass parameters
        ShootingCollider col = bullet.GetComponent<ShootingCollider>();
        // FIring bullet
        Rigidbody2D rigid = bullet.GetComponent<Rigidbody2D>();
        rigid.velocity = direction.normalized * speed;

        col.User = user;
        col.Action(ability);
}

    private float GetDegree(Vector2 direction) {

        float degree = (float)((Mathf.Atan2(direction.x, direction.y) / Math.PI) * 180f);
        if (degree < 0) degree += 360f;

        return degree;
    }
}
