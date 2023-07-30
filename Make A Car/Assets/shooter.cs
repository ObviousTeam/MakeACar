using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR;

public class shooter : MonoBehaviour
{
    public GameObject projectile;
    public int ammocount = 10;
    public int bulletDamage = 50;

    public void Fire()
    {
        if(ammocount > 0)
        {
            GameObject newBullet = Instantiate(projectile, this.transform.position, this.transform.rotation);
            newBullet.GetComponent<bullet>().bulletDamage = bulletDamage;
            ammocount--;
        } else
        {
            StartCoroutine(waitor());
        }
    }
    IEnumerator waitor()
    {
        yield return new WaitForSeconds(3);
        ammocount = 10;
    }
}
