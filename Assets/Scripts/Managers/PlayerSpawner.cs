using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;

public class PlayerSpawner : MonoBehaviour
{
    public GameObject player;

    public GameObject blockControlPanel;

    [SerializeField] private Transform[] spawnPoints;
    //[SerializeField] private Color[] colors;                    ** Couldn't figure out player color change in time ** 


    void Start()
    {
        blockControlPanel.SetActive(true);
        Vector2 playerSpawn = new Vector2(spawnPoints[PhotonNetwork.CurrentRoom.PlayerCount - 1].position.x, spawnPoints[PhotonNetwork.CountOfPlayers - 1].position.y);
        PhotonNetwork.Instantiate(player.name, playerSpawn, Quaternion.identity);
        //player.transform.GetChild(0).GetComponent<SpriteRenderer>().color = colors[PhotonNetwork.CurrentRoom.PlayerCount - 1]; 
    }

    private void Update()
    {
        if (PhotonNetwork.CurrentRoom.PlayerCount > 1)
        {
            blockControlPanel.SetActive(false);
        }
    }
}
