using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour {

	public float xRange;
	public float yMin = 0.01f;
	public float yMax=1f;
	public float xPos,yPos;

	public GameObject prefab;
	private GameObject[] plats;
	public int arraySize;
	private int currentPlat;

	public float TimeToReuse=2f;
	public float time;

	Platform p;
	void Start () {
		p = Platform.instance;
		plats= new GameObject[arraySize];
		time = 0;
		currentPlat = 0;
		for (int i = 0; i < arraySize; i++) {
			xPos = Random.Range (-xRange, xRange);
			yPos += Random.Range (yMin, yMax);
			Vector2 pos = new Vector2 (xPos, yPos);
			plats [i] = (GameObject)Instantiate (prefab, pos, Quaternion.identity);
		}
	}

	void Update () {
		time += Time.deltaTime;
//		Debug.Log (p.invisible);
		if (time>=TimeToReuse) {
			time = 0;
//			p.invisible = false;
			xPos = Random.Range (-xRange, xRange);
			yPos += Random.Range (yMin, yMax);
			plats [currentPlat].transform.position = new Vector2 (xPos, yPos);
			currentPlat += 1;
			if (currentPlat >= arraySize) {
				currentPlat = 0;
			}
		}
	}


}
