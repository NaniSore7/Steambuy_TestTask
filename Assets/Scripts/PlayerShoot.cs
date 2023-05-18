using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerShoot : MonoBehaviour
{
    PlayerControls shootInput;

    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float bulletSpeed;
    [SerializeField] private Transform shootPos;

    [SerializeField] private float reloadTime;
    private float lastShotTime;

    private bool playerShooting = false;

    private void Awake()
    {
        shootInput = new PlayerControls();
    }

    private void Update()
    {
        if (playerShooting)
        {
            float timeSinceLastShot = Time.time - lastShotTime;

            if (timeSinceLastShot >= reloadTime)
            {
                FireBullet();

                lastShotTime = Time.time;
            }
        }
    }

    private void OnEnable()
    {
        shootInput.Enable();
        shootInput.Player.Shoot.performed += OnShootingPerformed;
        shootInput.Player.Shoot.canceled += OnShootingCanceled;
    }

    private void FireBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab, shootPos.position, transform.rotation);
        Rigidbody2D bulletRB = bullet.GetComponent<Rigidbody2D>();

        bulletRB.velocity = bulletSpeed * transform.up;
    }
    private void OnShootingPerformed(InputAction.CallbackContext value)
    {
        playerShooting = true;
    }
    private void OnShootingCanceled(InputAction.CallbackContext value)
    {
        playerShooting = false;
    }

    private void OnDisable()
    {
        shootInput.Disable();
        shootInput.Player.Shoot.performed -= OnShootingPerformed;
        shootInput.Player.Shoot.canceled -= OnShootingCanceled;
    }
}
