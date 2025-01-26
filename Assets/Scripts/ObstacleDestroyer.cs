using System.Collections;
using UnityEngine;

public class ObstacleDestroyer : MonoBehaviour
{
    public SoundManager soundManager;
    private float screenHeight;
    public float destroySoundDelay = 0.5f; // Time delay before playing the destroy sound

    void Start()
    {
        // Calculate the screen height
        screenHeight = Camera.main.orthographicSize * 2f;
    }

    void Update()
    {
        // Destroy the object if it goes below the bottom of the screen
        if (transform.position.y < -screenHeight / 2f)
        {
            StartCoroutine(PlayDestroySoundWithDelay());
            Destroy(gameObject);
        }
    }

    private IEnumerator PlayDestroySoundWithDelay()
    {
        Debug.Log("sound play");
        yield return new WaitForSeconds(destroySoundDelay);
        soundManager.PlayRandomDestroySound();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player hit");
        }
    }
}
