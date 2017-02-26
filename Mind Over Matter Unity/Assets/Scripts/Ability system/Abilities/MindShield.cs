using UnityEngine;
using System.Collections;

public class MindShield : Ability {

    public const string name = "MindShield",
                        description = "A surrounding shield that blocks all incoming damage. Enemies inside the shield will get damaged, but damage is not blocked anymore";
    private const float blockingDamage = 100f,
                        cooldown = 4f,
                        radius = 2f,
                        effectDuration = 3f,
                        effectDamage = 10f,
                        damageTickDuration = 1f,
                        slowPercentage = 30f;

    public MindShield(Animator animator)
        : base(new BasicObjectInformation(name, description), cooldown) {

        this.Anim = animator;

        Protection protection = new Protection();
        this.Behaviours.Add(protection);

        AreaOfEffect aoe = new AreaOfEffect(radius, effectDuration, effectDamage, damageTickDuration);
        this.Behaviours.Add(aoe);

        Snare snare = new Snare(effectDuration, slowPercentage);
        this.Behaviours.Add(snare);
    }
}
