using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using Photon.Pun;

public class PlayerShoot : MonoBehaviour
{
    private PhotonView phView;

    PlayerControls shootInput;
    GameObject bullet;

    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform shootPos;

    [SerializeField] private float reloadTime;
    private float lastShotTime;

    private bool playerShooting = false;

    private void Awake()
    {
        phView = GetComponent<PhotonView>();

        shootInput = new PlayerControls();
    }

    private void Update()
    {
        if (!phView.IsMine) return;

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
        bullet = PhotonNetwork.Instantiate(bulletPrefab.name, shootPos.position, transform.rotation);
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
