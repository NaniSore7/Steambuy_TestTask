using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;

public class PlayerSpawner : MonoBehaviour
{
    public GameObject player;

    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private Color[] colors;


    void Start()
    {        
        Vector2 playerSpawn = new Vector2(spawnPoints[PhotonNetwork.CurrentRoom.PlayerCount - 1].position.x, spawnPoints[PhotonNetwork.CountOfPlayers - 1].position.y);
        PhotonNetwork.Instantiate(player.name, playerSpawn, Quaternion.identity);
    }
}
