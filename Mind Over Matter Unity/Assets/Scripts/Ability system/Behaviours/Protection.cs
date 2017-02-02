using UnityEngine;
using System.Collections;

public class Protection : AbilityBehaviours {

    private const string name = "Protection",
                          description = "Blocks incoming damage from different sides";
    private const ImpactTime impactTime = ImpactTime.Beginning;

    public Protection()
        : base(new BasicObjectInformation(name, description), impactTime) {
    }

    public override void Action(GameObject player, GameObject enemy) {
    }
}
