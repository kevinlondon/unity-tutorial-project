using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	// Summary:
	// 1: The speed of the ship.
	public Vector2 speed = new Vector2(50, 50);

	// Store the movement.
	public Vector2 movement;

	// Update is called once per frame
	void Update () {
		// Retrieve axis info
		float inputX = Input.GetAxis("Horizontal");
		float inputY = Input.GetAxis("Vertical");

		// Movement per direction
		movement = new Vector2 (
			speed.x * inputX,
			speed.y * inputY);
	}

	void FixedUpdate() {
		// Move the game object.
		rigidbody2D.velocity = movement;
	}
}
