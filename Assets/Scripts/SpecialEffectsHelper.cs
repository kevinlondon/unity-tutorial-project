using UnityEngine;
using System.Collections;

// <summary> Creating instance of particles from code with no effect. </summary>

public class SpecialEffectsHelper : MonoBehaviour {
	// <summary>
	// Singleton
	// </summary>
	public static SpecialEffectsHelper Instance;
	public ParticleSystem smokeEffect;
	public ParticleSystem fireEffect;

	void Awake() {
		// register the singleton
		if (Instance != null) {
			Debug.LogError ("Multiple instnaces of SpecialEffectsHelper!");
		}

		Instance = this;
	}

	// <summary>
	// Create an explosion at the given location.
	// </summary>
	// <param name="position"></param>
	public void Explosion(Vector3 position) {
		// Smoke on the water
		instantiate(smokeEffect, position);
		instantiate(fireEffect, position);
	}

	// <summary>
	// Instantiate a Particle system from prefab.
	// </summary>
	// <param name="prefab"></param>
	// <returns></returns>
	private ParticleSystem instantiate(ParticleSystem prefab, Vector3 position)
	{
		ParticleSystem newParticleSystem = Instantiate (
			prefab,
			position,
			Quaternion.identity
				) as ParticleSystem;

		// Make sure it will be destroyed.
		Destroy(
			newParticleSystem.gameObject,
			newParticleSystem.startLifetime
			);
		return newParticleSystem;
	}
}
