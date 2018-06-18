using UnityEngine;

public class Follow : MonoBehaviour {

	public Transform target;

	void Start(){
		Screen.sleepTimeout = SleepTimeout.NeverSleep;
	}
	void LateUpdate () {
		if (target != null) {
			if (target.position.y > transform.position.y) {//If y position of characerter is more than of camera's then, move the camera to character's position
				transform.position = new Vector3 (transform.position.x, target.position.y, transform.position.z); 
			}
		}
	}
}
