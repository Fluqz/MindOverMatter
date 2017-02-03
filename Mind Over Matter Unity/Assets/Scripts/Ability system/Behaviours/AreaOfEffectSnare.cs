using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

public class AreaOfEffectSnare : AbilityBehaviours {

    private const string name = "Area Of Effect Snare",
                          description = "A radius of snare";
    private const ImpactTime impactTime = ImpactTime.Beginning;
    private float areaRadius,
                    effectDuration,
                    slowPercentage;
    private bool isOccupied;
    private Stopwatch durationTimer = new Stopwatch();


    public AreaOfEffectSnare(float areaRad, float effectDur, float slowPerc)
        : base(new BasicObjectInformation(name, description), impactTime) {
        areaRadius = areaRad;
        effectDuration = effectDur;
        slowPercentage = slowPerc;
        isOccupied = false;
    }

    public override void Action(GameObject player) {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach(GameObject go in enemies) {
            if(Vector3.Distance(go.transform.position, player.transform.position) < areaRadius) {
                
            }
        }
        //if (Vector3.Distance(enemy.transform.position, player.transform.position) < areaRadius) { }
    }

}