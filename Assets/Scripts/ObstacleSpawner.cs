using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public float spawnInterval = 2f;
    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnObstacle();
            timer = 0f;
        }
    }

    void SpawnObstacle()
    {
        // Randomly spawn obstacles at the top of the screen
        float randomX = Random.Range(-5f, 5f);  // Random X position
        Instantiate(obstaclePrefab, new Vector3(randomX, Camera.main.orthographicSize, 0f), Quaternion.identity);
    }
}
