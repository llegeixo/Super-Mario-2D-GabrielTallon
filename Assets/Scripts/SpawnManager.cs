using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int enemyToSpawn;

    //public Transform[] spawnPositions = new Transform[3];
    public Transform[] spawnPositions;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemy", 2f, 1.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if(enemyToSpawn == 0)
        {
            CancelInvoke();
        }
    }

    void SpawnEnemy()
    {
        //spawnea un enemigo en un punto aleatorio
        /*Transform selectedSpawn = spawnPositions[Random.Range(0, spawnPositions.Length)];

        Instantiate(enemyPrefab, selectedSpawn.position, selectedSpawn.rotation);*/

        foreach (Transform spawn in spawnPositions)
        {
            Instantiate(enemyPrefab, spawn.position, spawn.rotation);
        }

        /*for (int i = 0; i < spawnPositions.Length; i++)
        {
            Instantiate(enemyPrefab, spawnPositions[i].position, spawnPositions[i].rotation);
        }*/

        /*int i = 0;
        while (i < spawnPositions.Length)
        {
            Instantiate(enemyPrefab, spawnPositions[i].position, spawnPositions[i].rotation);
            i++;
        }*/

        /*int i = 0;
        do
        {
            Instantiate(enemyPrefab, spawnPositions[i].position, spawnPositions[i].rotation);
            i++;
        } while (i < spawnPositions.Length);*/

        enemyToSpawn--;
    }
}
