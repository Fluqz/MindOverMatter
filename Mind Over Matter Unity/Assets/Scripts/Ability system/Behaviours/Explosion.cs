using UnityEngine;
using System.Collections;

public class Explosion : AbilityBehaviour {

    private const string name = "Explosion",
                          description = "Radius of damage.";
    private const ImpactTime impactTime = ImpactTime.End;
    private float radius;

    public Explosion(float radius)
        : base(new BasicObjectInformation(name, description), impactTime){

        this.radius = radius;
    }

    public override void Action(GameObject user, Ability ability) {


    }
}
