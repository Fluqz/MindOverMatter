using UnityEngine;
using System.Collections;

public class SwordThrust : Ability {

    private const string name = "Sword Thrust",
                          description = "A powerfull sword hit.";
    private const int effectDamage = 70;
    private const float dotDamage = 5,
                        effectDuration = 2,
                        dotDuration = .3f,
                        cooldown = 1f;
    

    public SwordThrust()
        : base(new BasicObjectInformation(name, description), cooldown) {

        // bleeding effect
        DamageOverTime dot = new DamageOverTime(effectDuration, dotDamage, dotDuration);
        this.Behaviours.Add(dot);
    }
}
