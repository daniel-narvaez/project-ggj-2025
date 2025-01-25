using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject[] obstaclePrefabs; // List of obstacle prefabs
    public float spawnInterval = 2f;     // Time between obstacle spawns
    public float maxRotationAngle = 360f; // Maximum rotation angle for obstacles

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
      if (GameStateManager.Instance.currentState != GameState.Play)
        return;

      
        if (obstaclePrefabs.Length == 0)
        {
            Debug.LogWarning("No obstacle prefabs assigned to the spawner.");
            return;
        }

        // Randomize horizontal position within screen bounds
        float randomX = Random.Range(-screenWidth / 2f, screenWidth / 2f);

        // Set spawn position at the top of the screen
        Vector3 spawnPosition = new Vector3(randomX, (screenHeight / 2f + 20f), 0f);

        // Randomly select an obstacle prefab from the list
        GameObject selectedObstacle = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)];

        // Randomize rotation for all axes (X, Y, Z)
        float randomRotationX = Random.Range(0f, maxRotationAngle);
        float randomRotationY = Random.Range(0f, maxRotationAngle);
        float randomRotationZ = Random.Range(0f, maxRotationAngle);

        // Instantiate the selected obstacle with a random rotation
        GameObject obstacle = Instantiate(selectedObstacle, spawnPosition, Quaternion.Euler(randomRotationX, randomRotationY, randomRotationZ));
    }
}
