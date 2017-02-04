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

    public Ability(BasicObjectInformation aBasicInfo, float cd, AbilityType type, float dmg, float timeToCast, GameObject prefa) {
        objectInfo = aBasicInfo;
        cooldown = cd;
        abilityType = type;
        damage = dmg;
        castTime = timeToCast;
        behaviours = new List<AbilityBehaviours>();
        prefab = prefa;
        useable = true;
    }

    public void PerformAbility(GameObject player) {
        foreach(AbilityBehaviours b in this.behaviours) {
            if (prefab != null) {
                b.Action(player, prefab);
                Debug.Log("prefab");
            }
            else {
                b.Action(player);
                Debug.Log("no prefab");
            }
        }
    }


    public BasicObjectInformation AbilityInfo { get { return objectInfo; } }
    public List<AbilityBehaviours> Behaviours { get { return behaviours; } }
    public AbilityType GetAbilityType { get { return abilityType; } }
    public float Damage { get { return damage; } }
    public float Cooldown { get { return cooldown; } }
    public float CastTime { get { return castTime; } }
    public GameObject Prefab { get { return prefab; } set { prefab = value; } }
    public bool Useable { get { return useable; } set { useable = value; } }
}
