using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Debug = UnityEngine.Debug;
public class SpaceTravel : AbilityBehaviours {

    private const string name = "Space travel",
                          description = "Changes position of an object.";
    private const ImpactTime impactTime = ImpactTime.Beginning;
    private float distance;

    public SpaceTravel(float dist)
        : base(new BasicObjectInformation(name, description), impactTime) {
        distance = dist;
    }

    public override void Action(GameObject player, List<GameObject> prefabs, Ability ability) {
        Vector2 direction = PlayerInformation.Direction;

        // use distance
        Vector3 currentPlayerPosition = player.transform.position;
        player.transform.position = currentPlayerPosition + new Vector3(direction.x * distance, direction.y * distance, 0);
    }
}
