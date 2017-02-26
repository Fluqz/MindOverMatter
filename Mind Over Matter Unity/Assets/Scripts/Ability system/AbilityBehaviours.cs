﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AbilityBehaviours {

    private BasicObjectInformation objectInfo;
    private ImpactTime impactTime;

    public AbilityBehaviours(BasicObjectInformation info, ImpactTime aImpactTime) {
        objectInfo = info;
        impactTime = aImpactTime;
    }

    public enum ImpactTime {
        Beginning,
        Middle,
        End
    }

    public virtual void Action(GameObject player) {
        Debug.LogWarning("Attach Action");
    }
    public virtual void Action(GameObject player, List<GameObject> prefab) {
        Debug.LogWarning("Attach Action");
    }
    public virtual void Action(GameObject player, List<GameObject> prefab, Ability ability) {
        Debug.LogWarning("Attach Action");
    }

    public BasicObjectInformation AbilityBehaviorInfo { get { return objectInfo; } }
    public ImpactTime AbilityImpactTime { get { return impactTime; } }
}
