using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour {

	public GameObject prefab,platforms;
	public int size;
	public List<GameObject> plat;

	bool place=false;

	public float xPos,yPos=0.1f;
	public float xRange=2;
	public float yMin=0.01f;
	public float yMax= 1;

	public void Start () {
		plat = new List<GameObject> ();
		for (int i = 0; i < size; i++) {
			GameObject o = (GameObject)Instantiate(prefab);
			o.SetActive (false);
			plat.Add(o);
		}
	}

	void Update () {
		GetPlatform();
		if (place) {
			xPos = Random.Range (-xRange, xRange);
			platforms.transform.position = new Vector2 (xPos, yPos);
			platforms.SetActive (true);
			yPos += Random.Range (yMin, yMax);
			place = false;
		}
	}


	public void GetPlatform() {
		for (int i = 0; i < plat.Count; i++) {
			if (!plat [i].activeInHierarchy) {
				platforms=plat [i];
				place = true;
			}
		}
	}
}
