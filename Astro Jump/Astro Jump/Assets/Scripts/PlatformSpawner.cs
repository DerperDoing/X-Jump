using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour {

	public float xRange;
	public float yMin = 0.01f;
	public float yMax=1f;
	public float xPos,yPos;
	public float TimeToReuse=2f;
	public float time;
	PlatformPooler p;
	void Start () {
		
		p = PlatformPooler.Instance;
	}

	void Update () {
		xPos = Random.Range (-xRange, xRange);
		yPos += Random.Range (yMin, yMax);
		Vector2 position = new Vector2 (xPos, yPos);
		p.SpawnFromPool ("Normal", position);
	}
}
