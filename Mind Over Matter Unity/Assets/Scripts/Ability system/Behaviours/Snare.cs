using UnityEngine;
using System.Collections;
using System.Diagnostics;

public class Snare : AbilityBehaviours {

    private const string name = "Snare",
                             description = "Slowing effect";
    private const ImpactTime impactTime = ImpactTime.End;
    private float effectDuration;
    private float slowPercent;
    private GameObject prefab;


    public Snare(float effectDur, float slowPerc, GameObject prefab)
        : base(new BasicObjectInformation(name, description), impactTime) {
        effectDuration = effectDur;
        slowPercent = slowPerc;
        this.prefab = prefab;
    }

    public override void Action(GameObject player) {

    }

    private IEnumerator Slowing(float slow) {
        yield return new WaitForSeconds(effectDuration);
        
        yield return null;
    }
}
