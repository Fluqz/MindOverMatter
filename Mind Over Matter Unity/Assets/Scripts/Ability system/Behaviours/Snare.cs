using UnityEngine;
using System.Collections;
using System.Diagnostics;

public class Snare : AbilityBehaviours {

    private const string name = "Snare",
                             description = "Slowing effect";
    private const ImpactTime impactTime = ImpactTime.End;
    private float effectDuration;
    private float slowPercent;


    public Snare(float effectDur, float slowPerc)
        : base(new BasicObjectInformation(name, description), impactTime) {
        effectDuration = effectDur;
        slowPercent = slowPerc;
    }

    public override void Action(GameObject player, GameObject enemy) {
    }

    private IEnumerator Slowing(GameObject objectHit) {

        yield return new WaitForSeconds(effectDuration);
        
        yield return null;
    }
}
