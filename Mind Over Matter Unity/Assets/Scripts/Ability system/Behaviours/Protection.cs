using UnityEngine;
using System.Collections;

public class Protection : AbilityBehaviours {

    private const string name = "Protection",
                          description = "Blocks incoming damage from different sides";
    private const ImpactTime impactTime = ImpactTime.Beginning;
    private float damageToBlock;

    public Protection(float damage)
        : base(new BasicObjectInformation(name, description), impactTime) {
        damageToBlock = damage;
    }

    public override void Action(GameObject player, GameObject enemy) {
    }
}
