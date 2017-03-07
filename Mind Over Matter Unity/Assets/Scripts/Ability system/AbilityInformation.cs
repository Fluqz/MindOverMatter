using UnityEngine;
using System.Collections;

public class AbilityInformation {

    private string name,
                    description;
    private float damage,
                    castTime,
                    abilityDuration,
                    cooldown;
    private bool useable;

    public AbilityInformation(string name, string description, float damage, float castTime, float abilityDuration, float cooldown) {
        this.name = name;
        this.description = description;
        this.damage = damage;
        this.castTime = castTime;
        this.abilityDuration = abilityDuration;
        this.cooldown = cooldown;
        this.useable = true;
    }

    public string Name { get { return name; } }
    public string Description { get { return description; } }
    public float Damage { get { return damage; } }
    public float CastTime { get { return castTime; } }
    public float AbilityDuration { get { return abilityDuration; } }
    public float Cooldown { get { return cooldown; } }
    public bool Useable { get { return useable; } set { useable = value; } }
}
