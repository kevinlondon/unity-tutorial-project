using UnityEngine;
using System.Collections;

// <summary>
// Enemey generic behavior.
// </summary>

public class EnemyScript : MonoBehaviour {
    private WeaponScript[] weapons;
    private MoveScript movement;
    
    void Awake()
    {
        // Retrieve weapon only once.
        // This will retrieve the weapon from the child.
        weapons = GetComponentsInChildren<WeaponScript>();
        movement = GetComponent<MoveScript>();
        movement.speed = new Vector2(Random.Range(8, 13), Random.Range(8, 13));
    }

    // Fire on each frame (or try).
    void Update()
    {
        foreach (WeaponScript weapon in weapons)
        {
            // Auto fire!
            if (weapon != null && weapon.CanAttack)
            {
                weapon.Attack(true);
            }
        }
    }
}
