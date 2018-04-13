using System.Collections;
using UnityEngine;

public class Platform : MonoBehaviour {

	public float jumpForce,someVal;
	void Update()
	{
		if (gameObject.transform.position.y < Camera.main.transform.position.y - someVal){
			ObjectPooler.instance.DeletePlatform (gameObject);
		}
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.relativeVelocity.y <= 0) {
			Rigidbody2D rb = col.collider.GetComponent<Rigidbody2D> ();
			if (rb != null) {
				rb.velocity = new Vector2 (rb.velocity.x, jumpForce);
			}
		}
	}

}
