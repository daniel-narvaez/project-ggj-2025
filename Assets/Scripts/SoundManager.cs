using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [Header("Sound Settings")]
    public AudioClip[] destroySounds;
    public AudioClip[] objectMissSounds;
    public AudioClip[] playerHitSounds;

    [Tooltip("AudioSource to play the sounds.")]
    public AudioSource audioSource;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // Replace KeyCode.Space with any key you want
        {
            //PlayRandomDestroySound();
        }
    }

    public void PlayRandomDestroySound()
    {
        if (destroySounds.Length == 0 || audioSource == null)
        {
            Debug.LogWarning("No sounds or AudioSource assigned!");
            return;
        }

        int randomIndex = Random.Range(0, destroySounds.Length);
        AudioClip randomClip = destroySounds[randomIndex];
        audioSource.clip = randomClip;
        audioSource.Play();
    }

    public void PlayRandomObjectMissSound()
    {
        if (objectMissSounds.Length == 0 || audioSource == null)
        {
            Debug.LogWarning("No sounds or AudioSource assigned!");
            return;
        }

        int randomIndex = Random.Range(0, objectMissSounds.Length);
        AudioClip randomClip = objectMissSounds[randomIndex];
        audioSource.clip = randomClip;
        audioSource.Play();
    }

    public void PlayRandomPlayerHitSound()
    {
        if (playerHitSounds.Length == 0 || audioSource == null)
        {
            Debug.LogWarning("No sounds or AudioSource assigned!");
            return;
        }

        int randomIndex = Random.Range(0, playerHitSounds.Length);
        AudioClip randomClip = playerHitSounds[randomIndex];
        audioSource.clip = randomClip;
        audioSource.Play();
    }
}
