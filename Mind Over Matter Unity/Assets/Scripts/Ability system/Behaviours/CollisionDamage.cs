using UnityEngine;
using System.Collections;

public class CollisionDamage : AbilityBehaviour {
    private const string name = "Collision Damage",
                          description = "Damage on hit";
    private const ImpactTime impactTime = ImpactTime.Beginning;
    private float baseEffectDamage;

    public CollisionDamage(float baseEffectDmg)
        : base(new BasicObjectInformation(name, description), impactTime) {
        baseEffectDamage = baseEffectDmg;
    }

    public override void Action(GameObject user, Ability ability) {
        Animator anim = user.GetComponent<Animator>();

        AbilityCollision ac = user.AddComponent<AbilityCollision>();
        ac.User = user;
        ac.Action(ability);
    }
}
