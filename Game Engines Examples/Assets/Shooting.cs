using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject bulletPrefab; 

    public float fireRate = 3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject bullet = GameObject.Instantiate<GameObject>(bulletPrefab);
            bullet.transform.position = spawnPoint.position;
            bullet.transform.rotation = this.transform.rotation;
        }
    }
}
