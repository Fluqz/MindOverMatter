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

    public Teleport(Animator animator, int index)
        : base(new BasicObjectInformation(name, description), cooldown, AbilityType.ranged, effectDamage, timeToCast) {
        this.Index = index;
        this.Anim = animator;

        this.Behaviours.Add(new SpaceTravel(travelDistance));
        this.Behaviours.Add(new CollisionDamage(effectDamage));
    }

}
