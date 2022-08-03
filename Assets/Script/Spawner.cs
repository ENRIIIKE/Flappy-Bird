using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform parent;
    
    //Pipe
    [Header("Pipe Variables")]
    public GameObject pipe;

    public bool pipeSpawning;

    public float pipeSpawnTime;

    public float pipeValueY;

    //Cloud
    [Header("Cloud Variables")]

    public GameObject cloud;

    public bool cloudSpawning;

    public float cloudSpawnTimeMin;
    public float cloudSpawnTimeMax;

    public float cloudMinY;
    public float cloudMaxY;
    void Update()
    {
        if (!pipeSpawning)
        {
            StartCoroutine("SpawnPipe");
        }
        if (!cloudSpawning)
        {
            StartCoroutine("SpawnCloud");
        }
    }

    public IEnumerator SpawnPipe()
    {
        pipeSpawning = true;
        yield return new WaitForSeconds(pipeSpawnTime);

        GameObject pipeInstance =  Instantiate(pipe, transform);

        pipeInstance.transform.parent = parent;

        float randomY = Random.Range(pipeValueY, -pipeValueY);
        Vector2 spawnPosition = new Vector2(transform.position.x, randomY);
        pipeInstance.transform.position = spawnPosition;

        pipeSpawning = false;
    }
    public IEnumerator SpawnCloud()
    {
        cloudSpawning = true;

        float cloudSpawnTime = Random.Range(cloudSpawnTimeMin, cloudSpawnTimeMax);
        yield return new WaitForSeconds(cloudSpawnTime);

        GameObject cloudInstance = Instantiate(cloud, transform);

        cloudInstance.transform.parent = parent;

        float randomY = Random.Range(cloudMinY, cloudMaxY);
        cloudInstance.transform.position = new Vector2(transform.position.x, randomY);

        cloudSpawning = false;
    }
}
