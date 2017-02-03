using UnityEngine;
using System.Collections;
using System.Diagnostics;

public class DamageOverTime : AbilityBehaviours {

    private const string name = "Damage Over Time",
                          description = "A damage over time effect";
    private const ImpactTime impactTime = ImpactTime.Beginning;
    private float effectDuration,
                    effectDamage,
                    damageTickDuration;
    private Stopwatch durationTimer = new Stopwatch();

    public DamageOverTime(float effectDur, float effectDmg, float dotDur)
        : base(new BasicObjectInformation(name, description), impactTime) {
        effectDuration = effectDur;
        effectDamage = effectDmg;
        damageTickDuration = dotDur;
    }

    public override void Action(GameObject player) {
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
