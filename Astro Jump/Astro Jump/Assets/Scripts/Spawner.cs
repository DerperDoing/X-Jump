using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
	public int number=10;
	public float minY = 1f;
	public float maxY = 4f;
	public float xRange=9f;
	public GameObject platformPrefab;
	public float spawnRate=3.5f;

	private float xPos,yPos;
	private int currentPlatform=0;
	private GameObject[] platform;
	private float timeElapsed;

	void Start () {
		platform=new GameObject[number];
		//Created an array of platforms for reusing it(Object Pooling)
		//Instantiating the platforms and storing in the array
		for (int i = 0; i < number; i++) {
			xPos = Random.Range (-xRange, xRange); //Getting the a random value for position of platform in x-axis
			yPos += Random.Range (minY, maxY); //Getting the a random value for position of platform in y-axis
			Vector2 pos=new Vector2(xPos,yPos);
			platform [i] = (GameObject)Instantiate (platformPrefab, pos, Quaternion.identity);
		}
	}

	//If time elapsed,say of one platform, is greater than the spawn rate of platforms, we spawn a new platform.
	void Update () {
		timeElapsed += Time.deltaTime;
		if (timeElapsed >= spawnRate) {
			timeElapsed = 0;
			xPos = Random.Range (-xRange, xRange);
			yPos += Random.Range (minY, maxY);
			platform [currentPlatform].transform.position = new Vector2 (xPos, yPos); //Placing a platform from the pool to a new postion
			currentPlatform += 1;
			if (currentPlatform >= number) { //Since traversing an array, after reaching the last index, start again from 0
				currentPlatform = 0;
			}
		}
	}
}
