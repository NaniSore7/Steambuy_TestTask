using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    private float bulletLifeTime;
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
