using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    BulletSpecification bullet;

    Rigidbody2D rigidBody;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void Shoot(GameObject bulletPrefab, Vector3 position, Quaternion rotation, float power)
    {
        GameObject bulletGo = Instantiate<GameObject>(bulletPrefab, position, rotation);
        Bullet bullet = bulletGo.GetComponent<Bullet>();
        bullet.BeShot(new Vector3(power, 0, 0));
    }

    private void BeShot(Vector3 power)
    {
        rigidBody.AddForce(power);
    }
}
