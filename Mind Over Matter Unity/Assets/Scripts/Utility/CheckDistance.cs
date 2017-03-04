using UnityEngine;
using System.Collections;

public class CheckDistance {

    Vector2 distance;
    
    public Vector2 CheckDistanceAToB(Vector3 from, Vector3 to) {
        distance.x = (to.x - from.x);
        distance.y = (to.y - from.y);
        return distance.normalized;
    }

}
