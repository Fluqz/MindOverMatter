using UnityEngine;
using System.Collections;

public class Ranged : AbilityBehaviours {

    private const string name = "Ranged",
                            description = "A ranged attack";
    private const ImpactTime impactTime = ImpactTime.End;

    private float distance;

    public Ranged(float dist)
        : base(new BasicObjectInformation(name, description), impactTime) {
        distance = dist;
    }

    public override void Action(GameObject player, GameObject enemy) {
        //Job.Make(checkDistance(playerObject.transform.position, prefab), true);
        //StartCoroutine(checkDistance(playerObject.transform.position, prefab));
    }

    private IEnumerator checkDistance(Vector3 playerPosition, GameObject prefab) {
        //float tempDistance = Vector3.Distance(playerPosition, prefab.transform.position);

       // while(tempDistance >= distance) {
          //  tempDistance = Vector3.Distance(playerPosition, prefab.transform.position);
      //  }

       // GameObject.Destroy(prefab);

        yield return null;
    }
    
}
