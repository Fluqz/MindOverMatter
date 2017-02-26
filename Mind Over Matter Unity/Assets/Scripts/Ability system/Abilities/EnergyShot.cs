using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnergyShot : Ability {

    public const string name = "Energy Shot",
                        description = "A energy shot dealing high damage.";
    private const float effectDamage = 50f,
                        cooldown = 0f,
                        castTime = .2f,
                        distance = 30f,
                        speed = 10 / 6;    

    public EnergyShot(Animator animator)
        : base(new BasicObjectInformation(name, description), cooldown, AbilityType.ranged, effectDamage, castTime) {

        this.Anim = animator;

        this.PrefabPaths.Add(Resources.Load("Prefabs/Abilities/EnergyShot") as GameObject);

        this.Behaviours.Add(new Ranged(distance, speed, effectDamage));
    }
}