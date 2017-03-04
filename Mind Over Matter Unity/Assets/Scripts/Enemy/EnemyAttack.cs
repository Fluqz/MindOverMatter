using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

public class EnemyAttack {
    private List<Ability> abilities;
    private Stopwatch cooldownTimer;
    private bool abilitiesDisabled,
                    isAttacking;
    private GameObject enemy;

    public EnemyAttack(GameObject enemy) {
        this.enemy = enemy;
        cooldownTimer = new Stopwatch();
        isAttacking = false;
    }

    public void SetAbility(Ability ability) {
        abilities.Add(ability);
    }

    public void RemoveAbility(Ability ability) {
        abilities.Remove(ability);
    }
    
    public void UseAbility(Ability ability) {
        cooldownTimer = new Stopwatch();
        cooldownTimer.Start();

        ability.Useable = false;
        isAttacking = true;
        ability.Anim.SetTrigger("Ability " + (ability.Index + 1));
        ability.PerformAbility(enemy);

        Job.make(AbilityCooldown(ability));
    }

    private IEnumerator AbilityCooldown(Ability ability) {
        while (cooldownTimer.IsRunning && cooldownTimer.Elapsed.TotalSeconds <= ability.Cooldown) {
            yield return null;
        }
        cooldownTimer.Stop();
        cooldownTimer.Reset();
        ability.Useable = true;

        yield break;
    }

    public List<Ability> Abilities { get { return abilities; } }
    public bool IsAttacking{ get { return isAttacking; } set { isAttacking = value; } }
}
