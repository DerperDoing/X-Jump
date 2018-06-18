using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour {
	public float speed=10f;
	float leftConstraint, rightConstraint;
	public float buffer;
	public GameObject gameOver;
	public GameObject restartButton;

	void Start()
	{
		leftConstraint = Camera.main.ScreenToWorldPoint (new Vector2 (0.0f, 0.0f)).x; //Finding the value of the left frame of visible area.
		rightConstraint = Camera.main.ScreenToWorldPoint (new Vector2 (Screen.width, 0.0f)).x;
		gameOver.SetActive (false);
		restartButton.SetActive (false);
	}

	void Update () {
		float x = Input.acceleration.x; //Accelerometer input from user's device
		transform.Translate (x, 0f, 0f); //Using only x value to make it move left/right

		if (this.transform.position.x 	< leftConstraint - buffer) { //If position of character is outside the left frame
			this.transform.position = new Vector2 (rightConstraint + buffer, this.transform.position.y); //Spawn it near the right frame of the screen
		} else if (this.transform.position.x > rightConstraint + buffer) {
			this.transform.position = new Vector2 (leftConstraint - buffer, this.transform.position.y);
		}
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.CompareTag("Kill Zone"))	//When contacts kill zone, kill the player and enable Options menu 
		{
			gameOver.SetActive (true);
			restartButton.SetActive (true);
			Destroy(this.gameObject);
		}
	}

	public void restartGame() //FUntionality of restart button in the option menu
	{
		SceneManager.LoadScene(0);
	}
}
