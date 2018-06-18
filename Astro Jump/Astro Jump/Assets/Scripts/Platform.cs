using System.Collections;
using UnityEngine;

public class Platform : MonoBehaviour {

	public float jumpForce,someVal;
	void Update()
	{	//If position of platform is below the bottom frame of camera, it is set False.
		if (gameObject.transform.position.y < (Camera.main.transform.position.y - someVal)){
			gameObject.SetActive(false);
		}
	}


	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.relativeVelocity.y <= 0) { //Means if collider falls from above only and not from any other direction
			if (this.gameObject.CompareTag("Break")) { //Used to check if collision with the platform is of type Break, then set it inactive
				this.gameObject.SetActive (false);
			}
			Rigidbody2D rb = col.collider.GetComponent<Rigidbody2D> ();
			if (rb != null) {
				rb.velocity = new Vector2 (rb.velocity.x, jumpForce);	//Given a upward thrust to the character
			}
		}
	}

}
