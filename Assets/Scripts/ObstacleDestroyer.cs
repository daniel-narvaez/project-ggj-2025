using UnityEngine;

public class ObstacleDestroyer : MonoBehaviour
{
    public SoundManager soundManager;
    private float screenHeight;

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
            
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Debug.Log("player hit");
        }
    }
}
