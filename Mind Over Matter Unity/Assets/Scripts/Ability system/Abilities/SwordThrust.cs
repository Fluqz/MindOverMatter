using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SwordThrust : Ability {

    private const string name = "Sword Thrust",
                          description = "A powerfull sword hit.";
    private const int effectDamage = 70;
    private const float effectDuration = .2f,
                        dotDuration = .3f,
                        cooldown = .2f,
                        range = .2f,
                        timeToCast = .1f;
    private int dotDamage = 5;
    private GameObject sword = Resources.Load("Prefabs/Abilities/SwordThrust") as GameObject;
    private GameObject dot = Resources.Load("Prefabs/Abilities/DOT") as GameObject;

    public SwordThrust(Animator animator, int index)
        : base(name, description, effectDamage, timeToCast, effectDuration, cooldown) {

        this.Anim = animator;
        this.Index = index;

        Behaviours.Add(new Meele(range, effectDamage, sword));

        Behaviours.Add(new DamageOverTime(effectDuration, dotDamage, dotDuration, dot));
    }
}
