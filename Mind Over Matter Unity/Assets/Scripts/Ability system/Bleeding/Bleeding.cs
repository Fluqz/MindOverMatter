using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bleeding {

    private Sprite[] sprites;

    public Bleeding(Sprite[] sprites) {
        this.sprites = sprites;
    }

    public void CreateBloodSplatter(GameObject victim, Vector2 direction) {

        Quaternion rotation = Quaternion.Euler(0, 0, Mathf.Atan2(direction.y*(-1), direction.x*(-1)) * Mathf.Rad2Deg);

        Vector3 position = new Vector3(victim.transform.position.x + direction.x * Random.Range(0f, 2f), victim.transform.position.y + direction.y * Random.Range(0f, 2f), victim.transform.position.z);

        GameObject blood = GameObject.Instantiate(new GameObject("Blood"), position, rotation);
        blood.GetComponent<SpriteRenderer>().sprite = null;
    }
}
