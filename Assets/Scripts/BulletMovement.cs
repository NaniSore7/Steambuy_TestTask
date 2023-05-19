using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class BulletMovement : MonoBehaviour
{
    [SerializeField] private float bulletSpeed;
    [SerializeField] private float bulletLifeTime;

    private void Update()
    {        
        Rigidbody2D bulletRB = GetComponent<Rigidbody2D>();
        bulletRB.velocity = bulletSpeed * transform.up;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }

}
