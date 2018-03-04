using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
	public float speed=10f;
	void FixedUpdate () {
		float x = Input.acceleration.x;
		transform.Translate (x, 0f, 0f);
	}
}
