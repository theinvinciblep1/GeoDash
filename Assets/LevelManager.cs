using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public Transform player;
    public GameObject obstaclePrefab;
    public float spawnDistance = 400f;  // Set initial spawnDistance to startSpawnPositionZ
    public float startSpawnPositionZ = 400f;

    private List<Vector3> usedPositions = new List<Vector3>();
    private bool initialSpawnStarted = false;

    // Start is called before the first frame update
    void Start()
    {
        // Optionally, you can spawn an initial set of obstacles if needed.
        // For example:
        // SpawnInitialObstacles();
    }

    private void Update()
    {
        // Check if the initial spawning has started
        if (!initialSpawnStarted && player.position.z > startSpawnPositionZ)
        {
            initialSpawnStarted = true;
        }

        // Continue regular spawning after the initial spawn
        if (initialSpawnStarted && player.position.z > spawnDistance)
        {
            SpawnObstacle();
        }
    }

    private void SpawnObstacle()
    {
        Vector3 spawnPosition = GetUniqueSpawnPosition();

        // Instantiate a new obstacle
        GameObject newObstacle = Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity);

        // Update spawnDistance for the next spawn
        spawnDistance += 5f; // Adjust as needed

        // Add the new spawn position to the used positions list
        usedPositions.Add(spawnPosition);
    }
  
    private Vector3 GetUniqueSpawnPosition()
    {
        Vector3 potentialSpawnPosition = Vector3.zero;
        bool positionIsUnique = false;

        // Keep trying to find a unique position until one is found
        while (!positionIsUnique)
        {
            // Calculate a potential spawn position
            float spawnX = Random.Range(-7.5f, 7.5f); // Adjust as needed
            float spawnY = 2.5f; // Adjust as needed
            float spawnZ = player.position.z + spawnDistance;

            potentialSpawnPosition = new Vector3(spawnX, spawnY, spawnZ);

            // Check if the position is unique (not already used)
            positionIsUnique = !usedPositions.Contains(potentialSpawnPosition);
        }

        return potentialSpawnPosition;
    }
}
