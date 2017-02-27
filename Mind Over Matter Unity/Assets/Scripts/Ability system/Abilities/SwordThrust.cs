using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SwordThrust : Ability {

    private const string name = "Sword Thrust",
                          description = "A powerfull sword hit.";
    private const int effectDamage = 70;
    private const float dotDamage = 5,
                        effectDuration = 2,
                        dotDuration = .3f,
                        cooldown = .2f,
                        range = .5f,
                        timeToCast = .1f;
    

    public SwordThrust(Animator animator)
        : base(new BasicObjectInformation(name, description), cooldown, AbilityType.meele, effectDamage, timeToCast, range) {

        this.Anim = animator;

        this.PrefabPaths.Add(Resources.Load("Prefabs/Abilities/SwordThrust") as GameObject);
        this.Behaviours.Add(new Meele(range, effectDamage));

        // bleeding effect
        //DamageOverTime dot = new DamageOverTime(effectDuration, dotDamage, dotDuration);
        //this.Behaviours.Add(dot);
    }
}
