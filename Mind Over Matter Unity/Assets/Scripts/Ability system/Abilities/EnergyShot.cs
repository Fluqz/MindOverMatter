using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnergyShot : Ability {

    public const string name = "Energy Shot",
                        description = "A energy shot dealing high damage.";
    private const float effectDamage = 50f,
                        cooldown = 2f,
                        castTime = 5f,
                        distance = 30f,
                        travelSpeed = 0f,
                        dotDuration = 5f,
                        dotTickDuration = 1f,
                        dotDamage = 3f;
    private GameObject shot = Resources.Load("Prefabs/Abilities/Cube") as GameObject;
    private GameObject dot = Resources.Load("Prefabs/Abilities/DOT") as GameObject;

    public EnergyShot(Animator animator, int index)
        : base(new BasicObjectInformation(name, description), cooldown, AbilityType.ranged, effectDamage, castTime) {

        this.Anim = animator;
        this.Index = index;

        this.Behaviours.Add(new Range(distance, travelSpeed, effectDamage, shot));
        this.Behaviours.Add(new DamageOverTime(dotDuration, dotDamage, dotTickDuration, dot));
    }
}