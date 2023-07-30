using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{

    public float speed = 100.0f;
    public int bulletDamage;

    void Start()
    {

        Destroy(this.gameObject, 2.0f);
    }
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

}
