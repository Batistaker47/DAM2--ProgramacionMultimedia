using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] private GameObject pipePrefab; // Prefab of the pipe object
    public int poolSize = 5; // Number of pipes in the object pool
    public float spawnTime = 1.5f; // Time between spawning pipes

    public float xSpawnPosition = 0.34f; // X-coordinate for pipe spawning
    public float minYPosition = 0; // Minimum Y-coordinate for pipe spawning
    public float maxYPosition = 1.0f; // Maximum Y-coordinate for pipe spawning

    public float pipeSpeed; // Speed at which pipes move

    private float timeElapsed; // Time elapsed since last pipe spawned
    private int poolCount; // Index of the current pipe in the pool
    private GameObject[] pool; // Array to store the pooled pipe objects

    void Start()
    {
        // Initialize the pool array
        pool = new GameObject[poolSize];

        // Create and deactivate the pipe objects in the pool
        for (int i = 0; i < poolSize; i++)
        {
            pool[i] = Instantiate(pipePrefab);
            pool[i].SetActive(false);
        }
    }

    void Update()
    {
        // Update the elapsed time
        timeElapsed += Time.deltaTime;

        // Check if it's time to spawn a new pipe
        if (timeElapsed > spawnTime)
        {
            SpawnGO();

            // Move the spawner to the left
            transform.position += Vector3.left * pipeSpeed * Time.deltaTime;
        }
    }

    private void SpawnGO()
    {
        // Reset the elapsed time
        timeElapsed = 0f;

        // Generate a random Y-position for the pipe
        float ySpawnPosition = Random.Range(minYPosition, maxYPosition);
        Vector2 spawnPosition = new Vector2(xSpawnPosition, ySpawnPosition);

        // Get the next pipe from the pool
        pool[poolCount].transform.position = spawnPosition;

        // Activate the pipe
        if (!pool[poolCount].activeSelf)
        {
            pool[poolCount].SetActive(true);
        }

        // Increment the pool count and wrap around if necessary
        poolCount++;
        if (poolCount == poolSize)
        {
            poolCount = 0;
        }
    }
}