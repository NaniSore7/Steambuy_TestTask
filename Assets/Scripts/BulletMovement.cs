using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    [SerializeField] private float bulletSpeed;

    private void Update()
    {        
        Rigidbody2D bulletRB = GetComponent<Rigidbody2D>();
        bulletRB.velocity = bulletSpeed * transform.up;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerStats hitTarget;
        hitTarget = collision.gameObject.GetComponent<PlayerStats>();
        if (hitTarget.GetComponent<PlayerStats>())
        {
            hitTarget.GetComponent<PlayerStats>().health -= 1;
            Debug.Log(hitTarget.GetComponent<PlayerStats>().health);
            if (hitTarget.health <= 0)
            {
                Destroy(hitTarget.gameObject);
            }
        }
        DestroyBullet();
    }

    private void DestroyBullet()
    {
        Destroy(this.gameObject);
    }
}
