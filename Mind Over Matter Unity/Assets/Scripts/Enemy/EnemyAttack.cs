using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

public class EnemyAttack {
    private List<Ability> abilities;
    private Stopwatch timer;
    private bool abilitiesDisabled,
                    isAttacking;
    private GameObject enemy;

    public EnemyAttack(GameObject enemy) {
        this.enemy = enemy;
        timer = new Stopwatch();
        isAttacking = false;
    }

    public void SetAbility(Ability ability) {
        abilities.Add(ability);
    }

    public void RemoveAbility(Ability ability) {
        abilities.Remove(ability);
    }
    
    public void UseAbility(Ability ability) {
        timer = new Stopwatch();
        timer.Start();

        ability.Useable = false;
        isAttacking = true;
        ability.Anim.SetTrigger("Ability " + (ability.Index + 1));

        Job.make(CastTime(ability));
    }

    private IEnumerator CastTime(Ability ability) {

        while (ability.CastTime != 0f && timer.IsRunning && timer.Elapsed.TotalSeconds <= ability.CastTime) {
            yield return null;
        }
        timer.Stop();
        timer.Reset();

        ability.PerformAbility(enemy);
        timer.Start();
        Job.make(AbilityCooldown(ability));

        yield break;
    }

    private IEnumerator AbilityCooldown(Ability ability) {
        while (timer.IsRunning && timer.Elapsed.TotalSeconds <= ability.Cooldown) {
            yield return null;
        }
        timer.Stop();
        timer.Reset();
        ability.Useable = true;

        yield break;
    }

    public List<Ability> Abilities { get { return abilities; } }
    public bool IsAttacking{ get { return isAttacking; } set { isAttacking = value; } }
}
