using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private GameObject deathPanel;
    public float health = 5;
    bool isDead = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        health -= 1;

        if (health <= 0)
        {
            isDead = true;
            Debug.Log("you died");
            deathPanel.SetActive(true);
            Destroy(gameObject);
        }
    }
}
