using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GunSpecification gun;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Shoot(GameObject bullet)
    {
        Bullet.Shoot(bullet, gameObject.transform.position, gameObject.transform.rotation, 10f);
    }
}
