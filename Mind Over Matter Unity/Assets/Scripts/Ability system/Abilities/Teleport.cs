using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Teleport : Ability {
    
    public const string name = "Teleport",
                        description = "An instant travel throughout space";
    private const float effectDamage = 50f,
                        cooldown = 1f,
                        travelDistance = 4f,
                        timeToCast = .2f,
                        abilityDuration = 2f;

    public Teleport(Animator animator, int index)
        : base(name, description, effectDamage, timeToCast, abilityDuration, cooldown) {
        this.Index = index;
        this.Anim = animator;

        this.Behaviours.Add(new SpaceTravel(travelDistance));
        this.Behaviours.Add(new CollisionDamage(effectDamage));
    }

}
