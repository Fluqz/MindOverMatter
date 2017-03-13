using UnityEngine;
using System.Collections;

public class Protection : AbilityBehaviour {

    private const string name = "Protection",
                          description = "Blocks incoming damage from different sides";
    private const ImpactTime impactTime = ImpactTime.Beginning;
    private GameObject prefab;
    private bool shielded;

    public Protection(GameObject prefab)
        : base(new BasicObjectInformation(name, description), impactTime) {

        this.prefab = prefab;

        this.shielded = false;
    }

    public override void Action(GameObject user, Ability ability) {
        if (user.transform.FindChild("Shield")) {
            GameObject s = user.transform.FindChild("Shield").gameObject;
            s.GetComponent<ShieldCollider>().DestroyGO(s);
        }
        Animator anim = user.GetComponent<Animator>();
        anim.SetTrigger("isAttacking");

        Vector3 userPos = new Vector3(user.transform.position.x, user.transform.position.y, 0);

        GameObject shield = GameObject.Instantiate(prefab, userPos, Quaternion.identity) as GameObject;
        shield.transform.parent = user.transform;
        shield.transform.name = prefab.name;
        shielded = true;
        // pass parameters
        ShieldCollider col = shield.GetComponent<ShieldCollider>();
        col.User = user;
        col.Action(ability);
    }
}
