using UnityEngine;
using System.Collections;

public class CreateNewWeapon : MonoBehaviour {

    private BaseWeapon newWeapon;

    void Start() {
        CreateWeapon();
        Debug.Log(newWeapon.ItemName);
        Debug.Log(newWeapon.ItemDescription);
        Debug.Log(newWeapon.WeaponType.ToString());
    }

    public void CreateWeapon() {

        newWeapon = new BaseWeapon();

        newWeapon.ItemName = "W" + Random.Range(1, 101);
        newWeapon.ItemDescription = "This is a new Weapon.";
        newWeapon.ItemID = Random.Range(1, 101);
        newWeapon.Stamina = Random.Range(1, 11);
        newWeapon.Endurance = Random.Range(1, 11);
        newWeapon.Intellect = Random.Range(1, 11);
        newWeapon.Strength = Random.Range(1, 11);

        ChooseWeaponType();

        newWeapon.SpellEffectID = Random.Range(1, 101);
    }

    private void ChooseWeaponType() {
        int randomTemp = Random.Range(1, 6);
        if (randomTemp == 1) {
            newWeapon.WeaponType = BaseWeapon.WeaponTypes.SWORD;
        }
        else if(randomTemp == 2) {
            newWeapon.WeaponType = BaseWeapon.WeaponTypes.STAFF;
        }
        else if (randomTemp == 3) {
            newWeapon.WeaponType = BaseWeapon.WeaponTypes.BOW;
        }
        else if (randomTemp == 4) {
            newWeapon.WeaponType = BaseWeapon.WeaponTypes.DAGGER;
        }
        else if (randomTemp == 5) {
            newWeapon.WeaponType = BaseWeapon.WeaponTypes.SHIELD;
        }
    }
}
