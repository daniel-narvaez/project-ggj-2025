using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject[] obstaclePrefabs; // List of obstacle prefabs
    public float spawnInterval = 2f;    // Time between obstacle spawns
    public float fallSpeed = 5f;        // Speed at which obstacles fall

    private float screenWidth;
    private float screenHeight;

    void Start()
    {
        // Calculate screen bounds in world space
        screenHeight = Camera.main.orthographicSize * 2f;
        screenWidth = screenHeight * Camera.main.aspect;

        // Start spawning obstacles
        InvokeRepeating(nameof(SpawnObstacle), 0f, spawnInterval);
    }

    void SpawnObstacle()
    {
        if (obstaclePrefabs.Length == 0)
        {
            Debug.LogWarning("No obstacle prefabs assigned to the spawner.");
            return;
        }

        // Randomize horizontal position within screen bounds
        float randomX = Random.Range(-screenWidth / 2f, screenWidth / 2f);

        // Set spawn position at the top of the screen
        Vector3 spawnPosition = new Vector3(randomX, (screenHeight / 2f + 5f), 0f);

        // Randomly select an obstacle prefab from the list
        GameObject selectedObstacle = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)];

        // Instantiate the selected obstacle
        GameObject obstacle = Instantiate(selectedObstacle, spawnPosition, Quaternion.identity);
    }
}
