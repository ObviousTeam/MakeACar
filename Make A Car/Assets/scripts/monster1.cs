using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class monster1 : MonoBehaviour
{
    public float speed = 2f;
    public int damage = 2;
    public Transform target1;
    public Transform target2;
    GameObject coinobject;
    public int CarHealth = 0;
    public GameObject monsterobject;
    int randomnumber = 0;
    private int dealtdamage;
    public int monsterhealth = 100;
    private bool canmove = true;
    private float damagetime = 2f;
    public Collision col;

    IEnumerator monsterupgrade()
    {
        while (true)
        {
            yield return new WaitForSeconds(60);
            damage = damage + 2;
            yield return new WaitForSeconds(30);
            damagetime = damagetime + 0.2f;
            yield return new WaitForSeconds(30);
            speed = speed + 0.2f;

        }
    }

    void Start()
    {
        CarHealth = GameObject.Find("Car1").GetComponent<cardeathscript>().CarHealth;
        randomnumber = UnityEngine.Random.Range(0, 2);
        Debug.Log(randomnumber);
        StartCoroutine(monsterupgrade());
    }

    void Update()
    {
        if (monsterhealth <=0) {
            Destroy(this.gameObject);
        }
        if (randomnumber == 0 && canmove)
        {
            transform.LookAt(target1);
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, target1.transform.position, Time.deltaTime * speed);
        }
        else if (randomnumber == 1 && canmove)
        {
            transform.LookAt(target2);
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, target2.transform.position, Time.deltaTime * speed);
        }
    }

    IEnumerator waiter()
    {
       CarHealth = CarHealth - damage;
       yield return new WaitForSeconds(damagetime);
       Debug.Log(CarHealth);
    }

    IEnumerator waiter2()
    {
        yield return new WaitForSeconds(damagetime);
        canmove = true;
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "car")
        {
            canmove = false;
            StartCoroutine(waiter());
        }

        else if (collision.gameObject.tag == "player")
        {
            canmove = false;
        }

        else if (collision.gameObject.tag == "wall")
        {
            Destroy(this.gameObject);
        }

         else if (collision.gameObject.tag == "bullet")
        {
            dealtdamage = collision.gameObject.GetComponent<bullet>().bulletDamage;
            monsterhealth = monsterhealth - dealtdamage;
        }
    }

    void OnCollisionExit(Collision col)
    {

        if (col.gameObject.tag == "player")
        {
            canmove = false;
            StartCoroutine(waiter2());
        }

        else if (col.gameObject.tag == "car")
        {
            canmove = false;
            StartCoroutine(waiter2());
        }
    }
}