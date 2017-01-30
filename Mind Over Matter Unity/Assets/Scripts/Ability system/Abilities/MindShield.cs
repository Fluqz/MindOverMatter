using UnityEngine;
using System.Collections;

public class MindShield : Ability {

    public const string name = "MindShield",
                        description = "A surrounding shield that blocks all incoming damage. Enemies inside the shield will get damaged, but damage is not blocked anymore";
    private const float blockingDamage = 100f,
                        cooldown = 4f,
                        radius = 2f,
                        effectDuration = 3f,
                        baseEffectDamage = 10f,
                        damageTickDuration = 1f,
                        slowPercentage = 30f;

    public MindShield()
        : base(new BasicObjectInformation(name, description), cooldown) {

        Protection protection = new Protection(blockingDamage);
        this.Behaviours.Add(protection);

        AreaOfEffect aoe = new AreaOfEffect(radius, effectDuration, baseEffectDamage, damageTickDuration);
        this.Behaviours.Add(aoe);

        Snare snare = new Snare(effectDuration, slowPercentage);
        this.Behaviours.Add(snare);
    }
}
