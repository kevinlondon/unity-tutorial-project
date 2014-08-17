using UnityEngine;
using System.Collections;

public class SoundEffectsHelper : MonoBehaviour {
    public static SoundEffectsHelper Instance;

    public AudioClip explosionSound;
    public AudioClip playerShotSound;
    public AudioClip enemyShotSound;

    void Awake()
    {
        // Register singleton
        if (Instance != null)
        {
            Debug.LogError("Multiple instances of SFXHelper!");
        }
        Instance = this;
    }

    public void MakeExplosionSound()
    {
        MakeSound(explosionSound);
    }

    public void MakePlayerShotSound()
    {
        MakeSound(playerShotSound);
    }

    public void MakeEnemyShotSound()
    {
        MakeSound(enemyShotSound);
    }

    // <summary>
    // Play a given sound.
    // </summary>
    // <param name="originalClip"></param>
    private void MakeSound(AudioClip originalClip)
    {
        // Not a 3d audio clip, position doesn't matter.
        AudioSource.PlayClipAtPoint(originalClip, transform.position);
    }
}
