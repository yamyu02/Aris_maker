using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    
    public GameObject bulletObject;
    public Transform bulletPos;

    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        Physics2D.IgnoreLayerCollision(5, 7);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer > 5)
        {
            timer = 0;
            print("Enemy Shoot");
            Shoot();
        }
    }

    void Shoot()
    {
        Instantiate(bulletObject, bulletPos.position, Quaternion.identity);
    }
}
