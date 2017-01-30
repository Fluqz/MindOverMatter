using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;

public class Ability {

    private BasicObjectInformation objectInfo;
    private List<AbilityBehaviours> behaviours;
    private AbilityType abilityType;
    private GameObject prefab;
    private bool useable;
    private float damage,
                  cooldown,
                  castTime;

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

    public void UseAbility(GameObject player, GameObject enemy) {
        foreach(AbilityBehaviours b in this.behaviours) {
            if(b.AbilityImpactTime == global::AbilityBehaviours.ImpactTime.Beginning) {
                b.Action(player, enemy);
            }
        }
    }

    public List<AbilityBehaviours> Behaviours { get { return behaviours; } }
    public AbilityType GetAbilityType { get { return abilityType; } }
    public float Damage { get { return damage; } }
    public float Cooldown { get { return cooldown; } }
    public float CastTime { get { return castTime; } }
    public GameObject Prefab { get { return prefab; } }
    public bool Useable { get { return useable; } set { useable = value; } }
}
