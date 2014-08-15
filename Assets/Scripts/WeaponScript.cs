using UnityEngine;
using System.Collections;

// <summary>
// Launch projectile.
// </summary>

public class WeaponScript : MonoBehaviour {
	// Designer Variables
	// Prefab for shooting.
	public Transform shotPrefab;

	// <summary>Cooldown in seconds between two shots.</summary>
	public float shootingRate = 0.25f;
	private float shootCooldown;

	void Start() {
        shootCooldown = Random.Range(0, 1);
	}

	void Update() {
		if (shootCooldown > 0) {
			shootCooldown -= Time.deltaTime;
		}
	}

	// Handling shooting from another script
	// Create a new projectile if possible.
	public void Attack(bool isEnemy)
	{
		if (CanAttack)
		{
			shootCooldown = shootingRate;

			// Create a new shot
			var shotTransform = Instantiate(shotPrefab) as Transform;

			// Assign position
			shotTransform.position = transform.position;

			// The isEnemy property
			ShotScript shot = shotTransform.gameObject.GetComponent<ShotScript>();
			if (shot != null) 
			{
				shot.isEnemyShot = isEnemy;
			}

			// Make the weapon shot always towards it.
			MoveScript move = shotTransform.gameObject.GetComponent<MoveScript>();
			if (move != null) {
				move.direction = this.transform.right; // Towards in 2d space is right of sprite.
			}
		}
	}

	// <summary> Is the weapon ready to create a new projectile? </summary>
	public bool CanAttack {
		get {
			return shootCooldown <= 0f;
		}
	}
}
