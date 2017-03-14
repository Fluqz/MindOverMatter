using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditorInternal;
using System.Reflection;
using System;

public class Depth : MonoBehaviour {

    public Collider2D obj;
    public Collider2D objTrigger;
    private BoxCollider2D boxCol;
    private SpriteRenderer objSprite;
    private string oldSortingLayer;
    private bool overlaps;
    private Collider2D other = new Collider2D();
    
    void Start () {
        boxCol = GetComponent<BoxCollider2D>();
        Physics2D.IgnoreCollision(obj, objTrigger, true);
        Physics2D.IgnoreCollision(obj, boxCol);
        objSprite = GetComponent<SpriteRenderer>();
        oldSortingLayer = objSprite.sortingLayerName;
        overlaps = false;
    }
	
	void OnTriggerEnter2D(Collider2D other) {
        if (Tools.CheckCollidersAsOneGameObejct(other))
            return;
        this.other = other;
        overlaps = true;
        CheckPositionY(true);
        StartCoroutine(UpdateWhileOverlapping());
    }

    void OnTriggerExit2D(Collider2D other) {
        overlaps = false;
        //CheckPositionY(false);
        Tools.EmptyColliderList();
        StopCoroutine(UpdateWhileOverlapping());
    }


    void CheckPositionY(bool entered) {
        if (entered) {
            if (other.CompareTag("Enemy")) {
                if (other.transform.position.y > this.gameObject.transform.position.y)
                    other.GetComponent<SpriteRenderer>().sortingOrder -= 1;
                else other.GetComponent<SpriteRenderer>().sortingOrder = 0;
            }
            else if (other.CompareTag("Player")) {
                if (other.transform.position.y > this.gameObject.transform.position.y)
                    objSprite.sortingLayerName = "InFrontOfPlayer";
                else objSprite.sortingLayerName = oldSortingLayer;
            }
        }
        else{
            if (other.CompareTag("Enemy")) {
                if (other.transform.position.y < transform.position.y)
                    other.GetComponent<SpriteRenderer>().sortingOrder += 1;
                else other.GetComponent<SpriteRenderer>().sortingOrder = 0;
            }
            else if (other.CompareTag("Player")) {
                if (other.transform.position.y < transform.position.y)
                    objSprite.sortingLayerName = oldSortingLayer;
                else objSprite.sortingLayerName = "InFrontOfPlayer";
            }
        }
    }

    IEnumerator UpdateWhileOverlapping() {
        while (overlaps) {
            CheckPositionY(true);
            yield return null;
        }
        StopCoroutine(UpdateWhileOverlapping());

        yield break;
    }

    public string GetSortingLayerNames(string layer) {
        Type internalEditorUtilityType = typeof(InternalEditorUtility);
        PropertyInfo sortingLayersProperty = internalEditorUtilityType.GetProperty("sortingLayerNames", BindingFlags.Static | BindingFlags.NonPublic);
        var temp = (string[])sortingLayersProperty.GetValue(null, new object[0]);
        foreach(string s in temp) {
            if (s.Contains(layer))
                return s;
        }
        return null;
    }
}
