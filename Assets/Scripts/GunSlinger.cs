using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSlinger : MonoBehaviour
{
    public GunSpecification[] guns;
    public Gun equippedGun;
    public GameObject bullets;
    public GameObject currentBullet;
    // Start is called before the first frame update
    void Start()
    {
        equippedGun = GetComponent<Gun>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Shoot()
    {
        equippedGun.Shoot(currentBullet);
    }

}
