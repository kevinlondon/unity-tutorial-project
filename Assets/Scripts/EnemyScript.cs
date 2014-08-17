using UnityEngine;
using System.Collections;

// <summary>
// Enemey generic behavior.
// </summary>

public class EnemyScript : MonoBehaviour {
    private bool hasSpawn;
    private WeaponScript[] weapons;
    private MoveScript moveScript;
    
    void Awake()
    {
        // Retrieve weapon only once.
        // This will retrieve the weapon from the child.
        weapons = GetComponentsInChildren<WeaponScript>();
        moveScript = GetComponent<MoveScript>();
    }

    void Start()
    {
        hasSpawn = false;
        moveScript.speed = new Vector2(Random.Range(8, 13), Random.Range(8, 13));
        // Disable everything.
        collider2D.enabled = false;
        moveScript.enabled = false;
        foreach (WeaponScript weapon in weapons)
        {
            weapon.enabled = false;
        }
    }
    // Fire on each frame (or try).
    void Update()
    {
        // Check if the enemy has spawned.
        if (hasSpawn == false)
        {
            if (renderer.isVisibleFrom(Camera.main))
            {
                Spawn();
            }
            return;
        }

        foreach (WeaponScript weapon in weapons)
        {
            // Auto fire!
            if (weapon != null && weapon.CanAttack)
            {
                weapon.Attack(true);
                SoundEffectsHelper.Instance.MakeEnemyShotSound();
            }
        }

        // Out of camera? Destroy it.
        if (renderer.isVisibleFrom(Camera.main) == false)
        {
            Destroy(gameObject);
        }
    }

    // Activate itself.
    private void Spawn()
    {
        hasSpawn = true;

        // Enable everything.
        collider2D.enabled = true;
        moveScript.enabled = true;
        foreach (WeaponScript weapon in weapons)
        {
            weapon.enabled = true;
        }
    }
}
