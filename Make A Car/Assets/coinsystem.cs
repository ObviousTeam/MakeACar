using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class coinsystem : MonoBehaviour
{
    public GameObject coinobject;
    public int bulletdamage = 50;
    public float secondsBetweenSpawn = 120f;
    public float elapsedTime = 0.0f;


    void Update()
    {
        elapsedTime += Time.deltaTime;

        if (elapsedTime > secondsBetweenSpawn)
        {
            elapsedTime = 0;
            Debug.Log(true);

            Vector3 spawnPosition = new Vector3(Random.Range(-60, 60), 0.5f, Random.Range(-60, 60));
            GameObject newcoin = (GameObject)Instantiate(coinobject, spawnPosition, Quaternion.Euler(0, 0, 0));
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "player")
        {
            GameObject.Find("Player/XR Origin/rotatedhand").GetComponent<shooter>().bulletDamage += 10;
            GameObject.Find("Player/XR Origin").GetComponent<DeviceBasedContinuousMoveProvider>().moveSpeed += 0.2f;
            Destroy(this.gameObject);
        }
    }
}