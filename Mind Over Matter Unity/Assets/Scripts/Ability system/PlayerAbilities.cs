using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

using Debug = UnityEngine.Debug;
public class PlayerAbilities : MonoBehaviour {

    private List<Ability> abilities;
    private Stopwatch cooldownTimer = new Stopwatch();
    private List<string> chosenAbilities;
    private bool abilitiesDisabled;

    void Awake() {
        abilities = new List<Ability>();
        chosenAbilities = new List<string>();
        chosenAbilities.Add("Teleport");
        LoadAbilities(chosenAbilities);
        abilitiesDisabled = false;
}

    void Update() {
        HandleAbilityInputs();
    }


    void LoadAbilities(List<string> chosenAbilities) {
        //for(int i = 0; i < 4; i++) {
            Abilities.Add(new Teleport());
            Abilities.Add(new MindShield());
    }

    void HandleAbilityInputs() {
        
    }

    public void Use(Ability ability) {
        cooldownTimer = new Stopwatch();
        cooldownTimer.Start();
        ability.Useable = false;
        ability.UseAbility(this.gameObject, GameObject.FindWithTag("Enemy"));
        
        StartCoroutine(StartCooldown(ability));
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
    
    public List<Ability> Abilities { get { return abilities; } }
}
