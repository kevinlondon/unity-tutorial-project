using UnityEngine;
using System.Collections;

// <summary>
// Handles hitpoints and damages.
// </summary>

public class HealthScript : MonoBehaviour {
	// Total HP
	public int hp = 1;

	// <summary>
	// Enemy or player?
	// </summary>
	public bool isEnemy = true;

	// <summary>
	// Inflicts damage and checks if the object should be destroyed.
	// </summary>
	// <param name="damageCount"></param>
	public void Damage(int damageCount)
	{
		hp -= damageCount;
		if (hp <= 0) {
			// It's dead!
			Destroy (gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D otherCollider)
	{
		// Is this a shot?
		ShotScript shot = otherCollider.gameObject.GetComponent<ShotScript> ();
		if (shot != null) {
			// Avoid friendly fire.
			if (shot.isEnemyShot != isEnemy) {
				Damage (shot.damage);
				// Destroy the shot!
				// Remember to always target the game object.
				Destroy (shot.gameObject);
			}
		}
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
