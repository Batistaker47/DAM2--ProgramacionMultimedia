using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] private GameObject pipePrefab;
    public int poolSize = 5;
    public float spawnTime = 1.5f;

    public float xSpawnPosition = 0.34f;
    public float minYPosition = 0;
    public float maxYPosition= 1.0f;

    public float pipeSpeed;
    private float timeElapsed;
    private int poolCount;
    private GameObject[] pool;
    void Start()
    {
        pool = new GameObject[poolSize];

        for (int i = 0; i < poolSize; i++)
        {
            pool[i] = Instantiate(pipePrefab);
            pool[i].SetActive(false);
        }
    }

    void Update()
    {
        timeElapsed += Time.deltaTime;
        if(timeElapsed > spawnTime)
        {
            SpawnGO();
            transform.position += Vector3.left * pipeSpeed * Time.deltaTime;
        }
    }

    private void SpawnGO()
    {
        timeElapsed = 0f;

        float ySpawnPosition = Random.Range(minYPosition, maxYPosition);
        Vector2 spawn = new Vector2(xSpawnPosition, ySpawnPosition);

        pool[poolCount].transform.position = spawn;

        if (!pool[poolCount].activeSelf)
        {
            pool[poolCount].SetActive(true);
        }
        ;
        poolCount++;

        if(poolCount == poolSize)
        {
            poolCount = 0;
        }
    }
}
