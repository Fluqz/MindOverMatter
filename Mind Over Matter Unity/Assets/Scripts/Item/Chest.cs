using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour {

    public GameObject prefab;
    public Sprite brokenChest;

    private bool broken;

    private int chestLife;

    private SpriteRenderer render;
    

	void Start () {
        chestLife = 3;
        broken = false;
        this.render = this.gameObject.GetComponent<SpriteRenderer>();
	}
	
	void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("CHEST HEEEEERE  " + other.transform.tag);
        if (!broken) {


            if (other.transform.CompareTag("Ability")) {
                chestLife -= 1;
                Debug.Log(chestLife);
            }

            if (chestLife == 0) {
                broken = true;
                DestroyChest();
            }
        }
    }

    void DestroyChest() {
        render.sprite = brokenChest;
        SpawnLoot(prefab);
        Destroy(this.gameObject.GetComponent<BoxCollider2D>());
    }

    void SpawnLoot(GameObject loot) {
        GameObject.Instantiate(loot, transform.position, Quaternion.identity);
    }

}
