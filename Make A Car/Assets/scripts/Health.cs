using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Health : MonoBehaviour
{

    public TMP_Text heath_text;

    public cardeathscript cardeathscript;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        heath_text.text = "Health: " + cardeathscript.CarHealth;  
    }
}
