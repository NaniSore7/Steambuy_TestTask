using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class PlayerStats : MonoBehaviour
{
    private float maxHealth = 5f;
    private float currentHealth = 5f;    
    public int coinsCollected;
    bool isDead = false;

    public float RemainingHealthPercentage
    {
        get
        {
            return currentHealth / maxHealth;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<BulletMovement>())
        {
            currentHealth -= 1;
            if (currentHealth <= 0)
            {
                isDead = true;
                Destroy(gameObject);
            }
        }

        if (collision.GetComponent<Coin>())
        {
            coinsCollected += 1;
        }
    }
}
