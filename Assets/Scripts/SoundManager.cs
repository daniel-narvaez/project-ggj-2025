using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [Header("Sound Settings")]
    public AudioClip[] destroySounds;
    public AudioClip[] objectMissSounds;
    public AudioClip[] playerHitSounds;
    public AudioClip[] blowSounds;

    [Tooltip("AudioSource to play the sounds.")]
    public AudioSource destroyAudioSource;
    public AudioSource objectMissAudioSource;
    public AudioSource playerHitAudioSource;
    public AudioSource blowAudioSource;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // Replace KeyCode.Space with any key you want
        {
            //PlayRandomDestroySound();
        }
    }

    public void PlayRandomDestroySound()
    {
        if (destroySounds.Length == 0 || destroyAudioSource == null)
        {
            Debug.LogWarning("No sounds or AudioSource assigned!");
            return;
        }

        int randomIndex = Random.Range(0, destroySounds.Length);
        AudioClip randomClip = destroySounds[randomIndex];
        destroyAudioSource.clip = randomClip;
        destroyAudioSource.Play();
    }

    public void PlayRandomObjectMissSound()
    {
        if (objectMissSounds.Length == 0 || objectMissAudioSource == null)
        {
            Debug.LogWarning("No sounds or AudioSource assigned!");
            return;
        }

        int randomIndex = Random.Range(0, objectMissSounds.Length);
        AudioClip randomClip = objectMissSounds[randomIndex];
        objectMissAudioSource.clip = randomClip;
        objectMissAudioSource.Play();
    }

    public void PlayRandomPlayerHitSound()
    {
        if (playerHitSounds.Length == 0 || playerHitAudioSource == null)
        {
            Debug.LogWarning("No sounds or AudioSource assigned!");
            return;
        }

        int randomIndex = Random.Range(0, playerHitSounds.Length);
        AudioClip randomClip = playerHitSounds[randomIndex];
        playerHitAudioSource.clip = randomClip;
        playerHitAudioSource.Play();
    }

    public void PlayRandomBlowSound()
    {
        if (blowSounds.Length == 0 || blowAudioSource == null)
        {
            Debug.LogWarning("No sounds or AudioSource assigned!");
            return;
        }

        int randomIndex = Random.Range(0, blowSounds.Length);
        AudioClip randomClip = blowSounds[randomIndex];
        blowAudioSource.clip = randomClip;
        blowAudioSource.Play();
        //audioSource.PlayOneShot(randomClip);
    }
}
