using UnityEngine;
using System.Collections;
using System.Diagnostics;

public class DamageOverTime : AbilityBehaviours {

    private const string name = "Damage Over Time",
                          description = "A damage over time effect";
    private const ImpactTime impactTime = ImpactTime.Beginning;
    private float effectDuration,
                    baseEffectDamage,
                    damageTickDuration;
    private Stopwatch durationTimer = new Stopwatch();

    public DamageOverTime(float ed, float bed, float dtd)
        : base(new BasicObjectInformation(name, description), impactTime) {
        effectDuration = ed;
        baseEffectDamage = bed;
        damageTickDuration = dtd;
    }

    public override void Action(GameObject player, GameObject enemy) {
       // StartCoroutine(DOT());
    }

    private IEnumerator DOT() {
        durationTimer.Start();

        while (durationTimer.Elapsed.TotalSeconds <= effectDuration) {
            // Damage here

            yield return new WaitForSeconds(damageTickDuration);
        }

        durationTimer.Stop();
        durationTimer.Reset();
        yield return null;
    }
}
