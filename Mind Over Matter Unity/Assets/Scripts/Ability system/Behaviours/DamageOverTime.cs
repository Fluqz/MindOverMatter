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
    private GameObject prefab;
    private Vector2 adjustToCenter = new Vector2(.5f, 1);
    private Stopwatch durationTimer = new Stopwatch();
    float temp = 0;

    public DamageOverTime(float effectDur, float effectDmg, float dotDur, GameObject prefab)
        : base(new BasicObjectInformation(name, description), impactTime) {
        effectDuration = effectDur;
        effectDamage = effectDmg;
        damageTickDuration = dotDur;
        this.prefab = prefab;
    }

    public override void Action(GameObject user, Ability ability) {

        Vector3 playerPos = new Vector3(user.transform.position.x + adjustToCenter.x, user.transform.position.y + adjustToCenter.y, 0);

        //GameObject dot = GameObject.Instantiate(prefab[0], playerPos, Quaternion.identity) as GameObject;
        //dot.transform.parent = user.transform;

        temp = 0;
        Job.make(DOT(user));
    }

    private IEnumerator DOT(GameObject user) {
        durationTimer.Start();
        while (durationTimer.IsRunning && durationTimer.Elapsed.TotalSeconds <= damageTickDuration) {
            yield return null;
        }

        temp += damageTickDuration;
        UnityEngine.Debug.Log(temp);

        durationTimer.Stop();
        durationTimer.Reset();

        if (effectDuration >= temp) {
            Job.make(DOT(user));
        }
        yield break;
    }
}
