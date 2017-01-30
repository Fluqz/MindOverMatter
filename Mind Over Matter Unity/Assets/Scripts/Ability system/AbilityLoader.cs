using UnityEngine;
using System.Collections;

public class AbilityLoader : MonoBehaviour {

    public const string path = "Assets/Scripts/Ability system/abilities.xml";

	void Start () {
        AbilityContainer ac = AbilityContainer.Load(path);

        foreach(AbilityA ability in ac.abilities) {
            print(ability);
        }
	}
	
}
