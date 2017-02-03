using UnityEngine;
using System.Collections;
using System.Diagnostics;

using Debug = UnityEngine.Debug;
public class PlayerAbilities {

    private Ability[] abilities;
    private Stopwatch cooldownTimer;
    private bool abilitiesDisabled;

    public PlayerAbilities() {
        abilities = new Ability[4];
        cooldownTimer = new Stopwatch();
    }

    public void AddOrReplaceAbility(Ability ab, int index) {
        PlayerInformation.Abilities[index] = ab;
        abilities[index] = PlayerInformation.Abilities[index];
    }

    public void RemoveAbility(int index) {
        PlayerInformation.Abilities[index] = null;
        abilities[index] = PlayerInformation.Abilities[index];
    }


    public void UseAbility(Ability ability) {
        cooldownTimer = new Stopwatch();
        cooldownTimer.Start();
        ability.Useable = false;
        ability.PerformAbility(PlayerInformation.PlayerGO);

        Job.make(StartCooldown(ability));
    }

    private IEnumerator StartCooldown(Ability ability) {
        while(cooldownTimer.IsRunning && cooldownTimer.Elapsed.TotalSeconds <= ability.Cooldown) {
            yield return null;
        }
        cooldownTimer.Stop();
        cooldownTimer.Reset();
        ability.Useable = true;

        yield return null;
    }
    
    public Ability[] Abilities { get { return abilities; } }
}
