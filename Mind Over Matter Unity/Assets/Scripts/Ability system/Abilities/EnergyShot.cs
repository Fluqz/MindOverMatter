using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnergyShot : Ability {

    public const string name = "Energy Shot",
                        description = "A energy shot dealing high damage.";
    private const float effectDamage = 50f,
                        cooldown = 3f,
                        castTime = .2f,
                        distance = 30f,
                        speed = 10 / 6;

    public EnergyShot(GameObject prefab)
        : base(new BasicObjectInformation(name, description), cooldown, AbilityType.ranged, effectDamage, castTime, prefab){
        Prefab = prefab;
        this.Behaviours.Add(new Ranged(distance, speed, effectDamage));
    }

}
