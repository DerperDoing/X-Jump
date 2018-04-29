using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
	public float speed=10f;
	float leftConstraint, rightConstraint;
	public float buffer;

	void Awake()
	{
		leftConstraint = Camera.main.ScreenToWorldPoint (new Vector2 (0.0f, 0.0f)).x;
		rightConstraint = Camera.main.ScreenToWorldPoint (new Vector2 (Screen.width, 0.0f)).x;
	}
	void FixedUpdate () {
		float x = Input.acceleration.x;
		transform.Translate (x, 0f, 0f);

		if (this.transform.position.x < leftConstraint - buffer) {
			this.transform.position = new Vector2 (rightConstraint + buffer, this.transform.position.y);
		} else if (this.transform.position.x > rightConstraint + buffer) {
			this.transform.position = new Vector2 (leftConstraint - buffer, this.transform.position.y);
		}
	}
}
