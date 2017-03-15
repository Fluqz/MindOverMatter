using UnityEngine;
using System.Collections;

public class MindShield : Ability {

    public const string name = "MindShield",
                        description = "A surrounding shield that blocks all incoming damage. Enemies inside the shield will get damaged, but damage is not blocked anymore";
    private const float blockingDamage = 100f,
                        cooldown = 7f,
                        radius = 2f,
                        damageTickDuration = 1f,
                        slowPercentage = 30f,
                        timeToCast = 1f,
                        duration = 5f;
    private const int effectDuration = 3;
    private const int effectDamage = 10;

    private GameObject aoe = Resources.Load("Prefabs/Abilities/AOE") as GameObject;
    private GameObject snare = Resources.Load("Prefabs/Abilities/AOE") as GameObject;
    private GameObject shield = Resources.Load("Prefabs/Abilities/Shield") as GameObject;

    public MindShield(Animator animator, int index)
        : base(name, description, effectDamage, timeToCast, duration, cooldown) {

        this.Anim = animator;
        this.Index = index;

        Behaviours.Add(new Protection(shield));

        Behaviours.Add(new AreaOfEffect(radius, effectDuration, effectDamage, damageTickDuration, aoe));

        Behaviours.Add(new Snare(effectDuration, slowPercentage, snare));
    }
}
