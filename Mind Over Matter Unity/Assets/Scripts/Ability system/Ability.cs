using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;

public class Ability {

    private string name,
                    description;
    private float damage,
                    castTime,
                    abilityDuration,
                    cooldown,
                    range;
    private bool useable;
    private int index;

    private List<AbilityBehaviour> behaviours;

    private Animator anim;

    public Ability(string name, string description, float damage, float castTime, float abilityDuration, float cooldown) {
        this.name = name;
        this.description = description;
        this.damage = damage;
        this.castTime = castTime;
        this.abilityDuration = abilityDuration;
        this.cooldown = cooldown;
        this.range = 0f;
        this.useable = true;
        behaviours = new List<AbilityBehaviour>();
    }

    public Ability(string name, string description, float damage, float castTime, float abilityDuration, float cooldown, float range) {
        this.name = name;
        this.description = description;
        this.damage = damage;
        this.castTime = castTime;
        this.abilityDuration = abilityDuration;
        this.cooldown = cooldown;
        this.range = range;
        this.useable = true;
        behaviours = new List<AbilityBehaviour>();
    }

    public void PerformAbility(GameObject user) {
        foreach(AbilityBehaviour b in this.behaviours) {
                b.Action(user, this);
                b.Action(user);
        }
    }
    
    public List<AbilityBehaviour> Behaviours { get { return behaviours; } }

    public string Name { get { return name; } }
    public string Description { get { return description; } }
    public float Damage { get { return damage; } }
    public float CastTime { get { return castTime; } }
    public float AbilityDuration { get { return abilityDuration; } }
    public float Cooldown { get { return cooldown; } }
    public float Range { get { return range; } }
    public bool Useable { get { return useable; } set { useable = value; } }
    public int Index { get { return index; } set { index = value; } }
    public Animator Anim { get { return anim; } set { anim = value; } }

}
