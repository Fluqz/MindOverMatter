using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bleeding {

    private GameObject prefab;

    public Bleeding(GameObject prefab) {
        this.prefab = prefab;
    }

    public void CreateBloodSplatter(Vector3 position, Vector2 direction) {

        Quaternion rotation = Quaternion.Euler(0, 0, Mathf.Atan2(direction.y*(-1), direction.x*(-1)) * Mathf.Rad2Deg);

        position = new Vector3(position.x + direction.x * Random.Range(0f, 2f), position.y + direction.y * Random.Range(0f, 2f), position.z);

        GameObject blood = GameObject.Instantiate(prefab, position, rotation);
    }
}
