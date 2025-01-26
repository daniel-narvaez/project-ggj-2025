using System.Collections;
using UnityEngine;

public class ObstacleDestroyer : MonoBehaviour
{
    public SoundManager soundManager;
    private float screenHeight;

    void Start()
    {
        // Calculate the screen height
        screenHeight = Camera.main.orthographicSize * 2f;
        soundManager = FindObjectOfType<SoundManager>();
    }

    void Update()
    {
        // Destroy the object if it goes below the bottom of the screen
        if (transform.position.y < -screenHeight / 2f)
        {
            soundManager.PlayRandomDestroySound();
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ITriggerHandler handler = other.transform.parent.GetComponent<ITriggerHandler>();
            if (handler != null)
            {
                handler.OnPlayerTrigger();
            }
        }
    }
}
