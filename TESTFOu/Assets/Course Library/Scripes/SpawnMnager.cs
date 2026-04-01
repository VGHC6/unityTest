using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMnager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform player;
    public float spawnRange=13;
    public int enemyCount;

    public int wave = 1;
    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemy(wave);
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<enemy>().Length;

        if(enemyCount == 0) 
        {
            wave++;
            SpawnEnemy(wave);
        }
    }

    public Vector3 RandomPosition()
    {
        float spawnPosx = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 spawnPosition = player.position+new Vector3(spawnPosx, 0, spawnPosZ);
        return spawnPosition;
    }


    public void SpawnEnemy(int wave)
    {
        for (int i = 0; i < wave; i++)
        {
            Instantiate(enemyPrefab, RandomPosition(), Quaternion.identity);
        }
    }
}
