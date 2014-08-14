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

		// Shooting.
		bool shoot = Input.GetButtonDown ("Fire1");
		shoot |= Input.GetButtonDown("Fire2");
		// Careful: for Mac users, ctrl + arrow is a bad idea.

		if (shoot)
		{
			WeaponScript weapon = GetComponent<WeaponScript>();
			if (weapon != null)
			{
				// False because the player is not an enemy.
				weapon.Attack (false);
			}
		}
	}

	void FixedUpdate() {
		// Move the game object.
		rigidbody2D.velocity = movement;
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        bool damagePlayer = false;

        // Collision with enemy!
        EnemyScript enemy = collision.gameObject.GetComponent<EnemyScript>();
        if (enemy != null)
        {
            // Kill them.
            HealthScript enemyHealth = enemy.GetComponent<HealthScript>();
            if (enemyHealth != null)
            {
                enemyHealth.Damage(enemyHealth.hp);
            }
            damagePlayer = true;
        }

        // Damage the player.
        if (damagePlayer)
        {
            HealthScript playerHealth = this.GetComponent<HealthScript>();
            if (playerHealth != null) {
                playerHealth.Damage(1);
            }
        }
    }
}
