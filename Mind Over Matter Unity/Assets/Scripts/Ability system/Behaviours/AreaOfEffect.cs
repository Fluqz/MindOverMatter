﻿using UnityEngine;
using System.Collections;
using System.Diagnostics;

public class AreaOfEffect : AbilityBehaviours {

    private const string name = "Area Of Effect",
                          description = "A wider attack";
    private const ImpactTime impactTime = ImpactTime.End;
    private float areaRadius,
                    effectDuration,
                    baseEffectDamage;
    private Stopwatch durationTimer = new Stopwatch();
    private bool isOccupied;
    private float damageTickDuration;


    public AreaOfEffect(float areaRad, float effectDur, float baseEffectDmg, float damageTickDur)
        : base(new BasicObjectInformation(name, description), impactTime) {
        areaRadius = areaRad;
        effectDuration = effectDur;
        baseEffectDamage = baseEffectDmg;
        damageTickDuration = damageTickDur;
        isOccupied = false;
    }

    public override void Action(GameObject player, GameObject enemy) {
  /*      CircleCollider2D bc;
        if (this.gameObject.GetComponent<CircleCollider2D>() == null)
            bc = this.gameObject.AddComponent<CircleCollider2D>();
        else
            bc = this.gameObject.GetComponent<CircleCollider2D>();

        bc.radius = areaRadius;
        bc.isTrigger = true;

        StartCoroutine(AOE());*/
    }

    private IEnumerator AOE() {
        durationTimer.Start();

        while (durationTimer.Elapsed.TotalSeconds <= effectDuration) {
            // Damage here

            yield return new WaitForSeconds(damageTickDuration);
        }

        durationTimer.Stop();
        durationTimer.Reset();
        yield return null;
    }
    
    void OnTriggerEnter(Collider other) {
        if (isOccupied) {
            //do damage
        }
        else
            isOccupied = true;
    }

    void OnTriggerExit(Collider other) {
        isOccupied = false;
    }
}