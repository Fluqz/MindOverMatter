using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Teleport : Ability {
    
    public const string name = "Teleport",
                        description = "An instant travel throughout space";
    private const float effectDamage = 50f,
                        cooldown = 1f,
                        travelDistance = 4f,
                        timeToCast = .2f;

    public Teleport(Animator animator)
        : base(new BasicObjectInformation(name, description), cooldown, AbilityType.ranged, effectDamage, timeToCast) {

        this.Anim = animator;

        SpaceTravel spaceTravel = new SpaceTravel(travelDistance);
        this.Behaviours.Add(spaceTravel);
        CollisionDamage collision = new CollisionDamage(effectDamage);
        this.Behaviours.Add(collision);
    }

}
