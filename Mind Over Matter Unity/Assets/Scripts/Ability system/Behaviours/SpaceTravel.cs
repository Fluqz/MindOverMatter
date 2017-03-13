using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Debug = UnityEngine.Debug;
public class SpaceTravel : AbilityBehaviour {

    private const string name = "Space Travel",
                          description = "Changes position of an object.";
    private const ImpactTime impactTime = ImpactTime.Beginning;
    private float distance;

    public SpaceTravel(float dist)
        : base(new BasicObjectInformation(name, description), impactTime) {
        distance = dist;
    }

    public override void Action(GameObject user, Ability ability) {
        Animator anim = user.GetComponent<Animator>();
        Vector2 direction = new Vector2(anim.GetFloat("DirectionX"), anim.GetFloat("DirectionY"));

        // use distance
        Vector3 currentPosition = user.transform.position;
        user.transform.position = currentPosition + new Vector3(direction.x * distance, direction.y * distance, 0);
    }

    public float Distance { get { return distance; } }
}
