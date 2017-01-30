﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Teleport : Ability {
    
    public const string name = "Teleport",
                        description = "An instant travel throughout space";
    private const float baseEffectDamage = 50f,
                        cooldown = 2f,
                        travelDistance = 3f;

    public Teleport()
        : base(new BasicObjectInformation(name, description), cooldown){

        SpaceTravel spaceTravel = new SpaceTravel(travelDistance);
        this.Behaviours.Add(spaceTravel);
        CollisionDamage collision = new CollisionDamage(baseEffectDamage);
        this.Behaviours.Add(collision);

    }

}
