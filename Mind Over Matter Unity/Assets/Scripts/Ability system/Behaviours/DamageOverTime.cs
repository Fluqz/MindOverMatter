using UnityEngine;
using System.Collections;
using System.Diagnostics;

public class DamageOverTime : AbilityBehaviour {

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

    public void InitDOT(GameObject user, GameObject victim, Ability ability) {
        Vector3 victimPos = new Vector3(victim.transform.position.x, victim.transform.position.y, 0);

        GameObject dot = GameObject.Instantiate(prefab, victimPos, Quaternion.identity) as GameObject;
        dot.name = prefab.name;
        dot.transform.parent = victim.transform;

        DOTDamage dotScript = dot.GetComponent<DOTDamage>();

        Transform victimChild = victim.transform.FindChild(prefab.name);
        if (victimChild && victimChild != dot) {
          //  if (victimChild.name == prefab.name)
               // dotScript.DestroyGameObject(victimChild.gameObject);
        }
        dotScript.User = user;
        dotScript.Victim = victim;
        dotScript.Duration = effectDuration;
        dotScript.Action(ability.Name);
        temp = 0;
        Job.make(DOT(user, dotScript));
    }

    private IEnumerator DOT(GameObject user, DOTDamage dotScript) {
        durationTimer.Start();
        while (durationTimer.IsRunning && durationTimer.Elapsed.TotalSeconds <= damageTickDuration) {
            yield return null;
        }

        temp += damageTickDuration;

        durationTimer.Stop();
        durationTimer.Reset();

        dotScript.MakeDamage(effectDamage);

        if (effectDuration >= temp) {
            Job.make(DOT(user, dotScript));
        }

        yield break;
    }
}
