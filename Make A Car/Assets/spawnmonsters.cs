using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnmonsters : MonoBehaviour
{


    public GameObject enemyObject;
    public float secondsBetweenSpawn;
    public float elapsedTime = 0.0f;


    void Update()
    {
        elapsedTime += Time.deltaTime;

        if (elapsedTime > secondsBetweenSpawn)
        {
            elapsedTime = 0;
            Debug.Log(true);

            Vector3 spawnPosition = new Vector3(Random.Range(-60, 60), 0.5f, Random.Range(-60, 60));
            GameObject newEnemy = (GameObject)Instantiate(enemyObject, spawnPosition, Quaternion.Euler(0, 0, 0));
        }
    }
}