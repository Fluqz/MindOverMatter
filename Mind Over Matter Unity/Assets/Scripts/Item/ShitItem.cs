using UnityEngine;
using System.Collections;

public class ShitItem : MonoBehaviour {

    Item item;

    void Start () {
        item = new Item("HealthPotion", "Restore health", Item.ItemType.HEALTHPOTION);
	}
	
    void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Player")) {
            PlayerInformation.AddItem(item);
            Destroy(this.gameObject);
        }
    }
}
