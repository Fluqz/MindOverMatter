﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class Tools {

    private static Vector2 distance;
       
    public static Vector2 CheckDistanceAToB(Vector3 from, Vector3 to) {
        distance.x = (to.x - from.x);
        distance.y = (to.y - from.y);
        return distance.normalized;
    }

    private static List<int> colliders;
    // Checks if another collider of the collider's gameobject already triggered
    public static bool CheckCollidersAsOneGameObejct(Collider2D other) {
        int id = 0;
        //if (other.gameObject.name != "Hitbox")
            id = other.gameObject.GetInstanceID();
        //else id = other.transform.parent.gameObject.GetInstanceID();

        if (colliders != null) {
            if (!colliders.Contains(id)) {
                colliders.Add(id);
                return false;
            }
            else return true;
        }
        else {
            colliders = new List<int>();
            colliders.Add(id);
            return false;
        }
    }
    // You need to empty the list or destroy the gameobject, after the player exits collision
    public static void EmptyColliderList() {
        colliders = null;
    } 
}