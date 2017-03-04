using UnityEngine;
using System.Collections;

public class Protection : AbilityBehaviours {

    private const string name = "Protection",
                          description = "Blocks incoming damage from different sides";
    private const ImpactTime impactTime = ImpactTime.Beginning;
    private GameObject prefab;

    public Protection(GameObject prefab)
        : base(new BasicObjectInformation(name, description), impactTime) {

        this.prefab = prefab;
    }

    public override void Action(GameObject player) {

    }
}
