using UnityEngine;
using System.Collections;

public class Ranged : AbilityBehaviours {

    private const string name = "Ranged",
                            description = "A ranged attack";
    private const ImpactTime impactTime = ImpactTime.End;

    private float distance;

    public Ranged(float dist)
        : base(new BasicObjectInformation(name, description), impactTime) {
        distance = dist;
    }

    public override void Action(GameObject player) {
    
    }

    private IEnumerator checkDistance(Vector3 playerPosition, GameObject prefab) {
       

        yield return null;
    }
    
}
