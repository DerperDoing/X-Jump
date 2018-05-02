﻿using UnityEngine;

public class Follow : MonoBehaviour {

	public Transform target;

	void Start(){
		Screen.sleepTimeout = SleepTimeout.NeverSleep;
	}
	void LateUpdate () {
		if (target != null) {
			if (target.position.y > transform.position.y) {
				transform.position = new Vector3 (transform.position.x, target.position.y, transform.position.z); 
			}
		}
	}
}
