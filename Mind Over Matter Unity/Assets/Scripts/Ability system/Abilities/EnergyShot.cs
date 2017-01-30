using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnergyShot : Ability {

    public const string name = "Energy Shot",
                        description = "A energy shot dealing high damage.";
    private const float baseEffectDamage = 50f,
                        cooldown = 3f,
                        castTime = .2f;

    public EnergyShot()
        : base(new BasicObjectInformation(name, description), cooldown, AbilityType.ranged, baseEffectDamage, castTime){

        this.Behaviours.Add(new Ranged(15f));
        this.Behaviours.Add(new AreaOfEffect(2f, 3f, 15f, 1f));
    }

}
