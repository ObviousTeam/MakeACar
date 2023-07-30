using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cardeathscript : MonoBehaviour
{

    public int CarHealth = 100000;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (CarHealth <= 0)
        {
            Debug.Log("gameover");
        }
    }
}
