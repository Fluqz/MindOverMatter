using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;

public class Ability {

    private BasicObjectInformation objectInfo;
    private List<AbilityBehaviours> behaviours;
    private AbilityType abilityType;
    private bool useable;
    private int index;
    private float damage,
                  cooldown,
                  castTime,
                    range;

    private Animator anim;

    public enum AbilityType {
        ranged,
        meele
    }

    public Ability(BasicObjectInformation aBasicInfo, float cd) {
        objectInfo = aBasicInfo;
        cooldown = cd;
        behaviours = new List<AbilityBehaviours>();
        cooldown = cd;
        useable = true;
    }

    public Ability(BasicObjectInformation aBasicInfo, float cd, AbilityType type) {
        objectInfo = aBasicInfo;
        cooldown = cd;
        abilityType = type;
        behaviours = new List<AbilityBehaviours>();
        useable = true;
    }

    public Ability(BasicObjectInformation aBasicInfo, float cd, AbilityType type, float dmg, float timeToCast) {
        objectInfo = aBasicInfo;
        cooldown = cd;
        abilityType = type;
        damage = dmg;
        castTime = timeToCast;
        behaviours = new List<AbilityBehaviours>();
        useable = true;
    }

    public Ability(BasicObjectInformation aBasicInfo, float cd, AbilityType type, float dmg, float timeToCast, float abilityRange) {
        objectInfo = aBasicInfo;
        cooldown = cd;
        abilityType = type;
        damage = dmg;
        castTime = timeToCast;
        range = abilityRange;
        behaviours = new List<AbilityBehaviours>();
        useable = true;
    }


    public void PerformAbility(GameObject user) {
        foreach(AbilityBehaviours b in this.behaviours) {
                b.Action(user, this);
                b.Action(user);
        }
    }


    public BasicObjectInformation AbilityInfo { get { return objectInfo; } }
    public List<AbilityBehaviours> Behaviours { get { return behaviours; } }
    public AbilityType GetAbilityType { get { return abilityType; } }
    public float Damage { get { return damage; } }
    public float Cooldown { get { return cooldown; } }
    public int Index { get { return index; } set { index = value; } }
    public float CastTime { get { return castTime; } }
    public float Range { get; set; }
    public bool Useable { get { return useable; } set { useable = value; } }
    public Animator Anim { get; set; }
}
