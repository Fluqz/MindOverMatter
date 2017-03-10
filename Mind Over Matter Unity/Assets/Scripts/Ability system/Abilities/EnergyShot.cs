using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnergyShot : Ability {

    public const string name = "Energy Shot",
                        description = "A energy shot dealing high damage.";
    private const float effectDamage = 10f,
                        abilityDuration = 10f,
                        cooldown = 0f,
                        castTime = 3f,
                        distance = 30f,
                        travelSpeed = 14f,
                        dotDuration = 5f,
                        dotTickDuration = 1f,
                        dotDamage = 3f;
    private GameObject shot = Resources.Load("Prefabs/Abilities/EnergyShot") as GameObject;
    private GameObject dot = Resources.Load("Prefabs/Abilities/DOT") as GameObject;

    public EnergyShot(Animator animator, int index)
        : base(name, description, effectDamage, castTime, abilityDuration, cooldown) { 
        this.Anim = animator;
        this.Index = index;

        this.Behaviours.Add(new Range(distance, travelSpeed, effectDamage, shot));
        this.Behaviours.Add(new DamageOverTime(dotDuration, dotDamage, dotTickDuration, dot));
    }

    public float DotDuration { get { return dotDuration; } }
}