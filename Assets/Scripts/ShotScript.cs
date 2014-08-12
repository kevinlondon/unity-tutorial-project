using UnityEngine;
using System.Collections;

public class ShotScript : MonoBehaviour {
	public int damage = 1;

	// Is this the player's or the enemy's projectile?
	public bool isEnemyShot = false;

	// Use this for initialization
	void Start () {
		// Avoid game leak by limiting time to live.
		Destroy (gameObject, 20);  // In 20 seconds.
	}
}
