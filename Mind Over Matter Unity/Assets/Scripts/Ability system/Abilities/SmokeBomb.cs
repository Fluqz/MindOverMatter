using UnityEngine;
using System.Collections;

public class SmokeBomb : Ability {

    private const string name = "Smoke Bomb",
                            description = "";
    private const float cooldown = 5f,
                        damage = 5f,
                        abilityDuration = 5f,
                        effectDuration = 4f,
                        tickDuration = 1f,
                        radius = 6f,
                        slow = 10f,
                        timeToCast = 1f,
                        range = 9f, 
                        travelSpeed = 5f;
    private GameObject shotPrefab = Resources.Load("") as GameObject;
    private GameObject slowPrefab = Resources.Load("") as GameObject;
    private GameObject dotPrefab = Resources.Load("") as GameObject;

    public SmokeBomb() 
        : base(name, description, damage, timeToCast, abilityDuration, cooldown) {

        Behaviours.Add(new Snare(effectDuration, slow, slowPrefab));

        Behaviours.Add(new Range(range, travelSpeed, damage, dotPrefab));

        Behaviours.Add(new DamageOverTime(effectDuration, damage, tickDuration, dotPrefab));
    }
}
