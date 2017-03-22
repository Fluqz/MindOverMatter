using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class Tools {

    private static Vector2 distance;
       
    public static Vector2 CheckDistanceAToB(Vector3 from, Vector3 to) {
        distance.x = (to.x - from.x);
        distance.y = (to.y - from.y);
        return distance.normalized;
    }

}
