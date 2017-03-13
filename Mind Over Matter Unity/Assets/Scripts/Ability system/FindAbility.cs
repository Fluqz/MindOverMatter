using UnityEngine;
using System.Collections;

public static class FindAbility {

    public static Ability GetAbility(string abilityName, GameObject user) {
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

    public static AbilityBehaviour GetAbilityBehaviour(string name, Ability ability) {
        foreach (AbilityBehaviour ab in ability.Behaviours) {
            if (ab.AbilityBehaviorInfo.ObjectName == name) {
                return ab;
            }
        }
        return null;
    }
}
