using UnityEngine;
using System.Collections;

public class Shot : MonoBehaviour {

    public GameObject prefab;

	void Start () {
	
	}
	
	void Update () {
        if (Input.GetKeyDown("space")) {
            Debug.Log("he");
            shoot(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        }
	}
    
    void shoot(float x, float y) {
        Instantiate(prefab, this.transform.position, transform.rotation);

        prefab.transform.Translate(x, y, 0);
        StartCoroutine(Shooting());
    }

    IEnumerator Shooting() {
        yield return null;
    }
}
