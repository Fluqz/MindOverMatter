using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AbilityBehaviour {

    private BasicObjectInformation objectInfo;
    private ImpactTime impactTime;

    public AbilityBehaviour(BasicObjectInformation info, ImpactTime aImpactTime) {
        objectInfo = info;
        impactTime = aImpactTime;
    }

    public enum ImpactTime {
        Beginning,
        Middle,
        End
    }

    public virtual void Action(GameObject user) {
        Debug.LogWarning("Attach Action");
    }
    public virtual void Action(GameObject user, GameObject prefab) {
        Debug.LogWarning("Attach Action");
    }
    public virtual void Action(GameObject user, Ability ability) {
        Debug.LogWarning("Attach Action");
    }

    public BasicObjectInformation AbilityBehaviorInfo { get { return objectInfo; } }
    public ImpactTime AbilityImpactTime { get { return impactTime; } }
}
