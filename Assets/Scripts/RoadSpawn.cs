using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadSpawn : MonoBehaviour
{
    public GameObject roadPrefab; // Prefab of the road segment
    public Transform player; // Reference to the player's Transform
    public float spawnDistance = 10f; // Distance between each road segment
    public int maxRoadSegments = 5; // Maximum number of road segments to keep active

    private Queue<GameObject> roadSegments = new Queue<GameObject>(); // Queue to track active road segments
    private Vector3 nextSpawnPosition; // Position for the next road segment

    void Start()
    {
        // Set the initial spawn position
        nextSpawnPosition = Vector3.zero;

        // Spawn initial road segments
        for (int i = 0; i < maxRoadSegments; i++)
        {
            SpawnRoadSegment();
        }
    }

    void Update()
    {
        // Check if the player is close to the last spawned segment
        if (player.position.z > nextSpawnPosition.z - (maxRoadSegments * spawnDistance))
        {
            // Spawn a new road segment in front of the player
            SpawnRoadSegment();

            // Remove and destroy the oldest road segment to avoid memory overflow
            if (roadSegments.Count > maxRoadSegments)
            {
                DestroyOldRoadSegment();
            }
        }
    }

    private void SpawnRoadSegment()
    {
        // Instantiate a new road segment at the next spawn position
        GameObject newSegment = Instantiate(roadPrefab, nextSpawnPosition, Quaternion.identity);

        // Add the new segment to the queue
        roadSegments.Enqueue(newSegment);

        // Update the next spawn position
        nextSpawnPosition.z += spawnDistance;
    }

    private void DestroyOldRoadSegment()
    {
        // Remove the oldest road segment from the queue and destroy it
        GameObject oldSegment = roadSegments.Dequeue();
        Destroy(oldSegment);
    }
}
