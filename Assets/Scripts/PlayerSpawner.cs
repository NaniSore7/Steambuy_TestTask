using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerSpawner : MonoBehaviour
{
    public GameObject player;


    void Start()
    {
        Vector2 testSpawn = new Vector2();
        testSpawn = Vector2.zero;
        PhotonNetwork.Instantiate(player.name, testSpawn, Quaternion.identity);
    }
}
