using UnityEngine;
using System.Collections;

public class Depth : MonoBehaviour {

    public BoxCollider2D obj;
    public BoxCollider2D objTrigger;
    private SpriteRenderer objSprite, otherSprite;
    
    void Start () {
        Physics2D.IgnoreCollision(obj, objTrigger, true);
        objSprite = GetComponent<SpriteRenderer>();
        
    }
	
	void OnTriggerEnter2D(Collider2D other) {
        otherSprite = other.gameObject.GetComponent<SpriteRenderer>();

        if (other.transform.position.y > transform.position.y)
            objSprite.sortingOrder = otherSprite.sortingOrder + 1;
        else objSprite.sortingOrder = otherSprite.sortingOrder - 1;
        if (otherSprite.sortingOrder > objSprite.sortingOrder)
            objSprite.sortingOrder = otherSprite.sortingOrder+1;
    }

    void OnTriggerExit2D(Collider2D other) {
        otherSprite = other.gameObject.GetComponent<SpriteRenderer>();
        if (otherSprite.sortingOrder < objSprite.sortingOrder)
            objSprite.sortingOrder = otherSprite.sortingOrder -1;
    }
}
