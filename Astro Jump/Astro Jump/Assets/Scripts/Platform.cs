using System.Collections;
using UnityEngine;

public class Platform : MonoBehaviour {

	public float jumpForce,waitSec;
	PlatformPooler p= PlatformPooler.Instance;

	void OnBecameInvisible()
	{
//		StartCoroutine (PutBack());
		Debug.Log("Invisble");
		this.gameObject.SetActive (false);
		p.poolDictionary [this.tag].Enqueue (this.gameObject);
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.relativeVelocity.y <= 0)
		{
			Rigidbody2D rb = col.collider.GetComponent<Rigidbody2D>();
			if (rb != null)
			{
				rb.velocity = new Vector2(rb.velocity.x, jumpForce);
			}
		}
	}

//	IEnumerator PutBack()
//	{
//		yield return new WaitForSeconds (waitSec);
//		this.gameObject.SetActive (false);
//		p.poolDictionary [this.tag].Enqueue (this.gameObject);
//	}

}
