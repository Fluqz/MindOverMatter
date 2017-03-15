using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;

public class Ability {

    private string name,
                    description;
    private int damage;
    private float castTime,
                    abilityDuration,
                    cooldown,
                    range;
    private bool useable;
    private int index;
    private string enemyTag, layerMaskName;

    private List<AbilityBehaviour> behaviours;

    private Animator anim;
    private GameObject user;

    public Ability(string name, string description, int damage, float castTime, float abilityDuration, float cooldown) {
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

    public Ability(string name, string description, int damage, float castTime, float abilityDuration, float cooldown, float range) {
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
        foreach (AbilityBehaviour b in this.behaviours) {
            b.Action(user, this);
            b.Action(user);
        }
    }

    public Ability GetAbility(string abilityName, GameObject user) {
        if (user.transform.CompareTag("Player")) {
            foreach (Ability a in PlayerInformation.Abilities) {
                if (a.Name == abilityName) {
                    return a;
                }
            }
        }
        else if (user.CompareTag("Enemy")) {
            foreach (Ability a in user.GetComponent<Enemy>().Abilities) {
                if (a.Name == abilityName) {
                    return a;
                }
            }
        }
        return null;
    }

    public AbilityBehaviour GetAbilityBehaviour(string name, Ability ability) {
        foreach (AbilityBehaviour ab in ability.Behaviours) {
            if (ab.AbilityBehaviorInfo.ObjectName == name) {
                return ab;
            }
        }
        return null;
    }

    private void SetOppositeTag(string tag) {
        if (tag == "Player")
            enemyTag = "Enemy";
        else enemyTag = "Player";
    }

    public string GetOppositeTag(string tag) {
        if (tag == "Player")
            return "Enemy";
        else return "Player";
    }

    private void SetAbilityLayerMaskFromUserTag(string tag) {
        if (tag == "Player")
            layerMaskName = "PlayerAbility";
        else {
            layerMaskName = "EnemyAbility";
        }
    }

    public List<AbilityBehaviour> Behaviours { get { return behaviours; } }

    public string Name { get { return name; } }
    public string Description { get { return description; } }
    public string LayerMaskName{ get { return layerMaskName; } }
    public string EnemyTag { get { return enemyTag; } }
    public int Damage { get { return damage; } }
    public float CastTime { get { return castTime; } }
    public float AbilityDuration { get { return abilityDuration; } }
    public float Cooldown { get { return cooldown; } }
    public float Range { get { return range; } }
    public bool Useable { get { return useable; } set { useable = value; } }
    public int Index { get { return index; } set { index = value; } }
    public Animator Anim { get { return anim; } set { anim = value; } }
    public GameObject User { get { return user; } }
}
