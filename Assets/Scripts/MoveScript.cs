using UnityEngine;
using System.Collections;

public class MoveScript : MonoBehaviour {
	public Vector2 speed = new Vector2(10, 10);
	public Vector2 direction = new Vector2(-1, 0);
	public Vector2 movement;
	
	// Update is called once per frame
	void Update () {
		movement = new Vector2 (
			speed.x * direction.x,
			speed.y * direction.y);
	}

	// Should be used with physics things.
	void FixedUpdate() {
		rigidbody2D.velocity = movement;
	}
}
