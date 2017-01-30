using UnityEngine;
using System.Collections;
using System.Diagnostics;

public class SpaceTravel : AbilityBehaviours {

    private const string name = "Space travel",
                          description = "Changes position of an object.";
    private const ImpactTime impactTime = ImpactTime.Beginning;
    private float distance;

    public SpaceTravel(float dist)
        : base(new BasicObjectInformation(name, description), impactTime) {
        distance = dist;
    }

    public override void Action(GameObject player, GameObject enemy) {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        // use distance

        player.transform.Translate(new Vector3(horizontal * distance, vertical * distance, 0));
    }

}
