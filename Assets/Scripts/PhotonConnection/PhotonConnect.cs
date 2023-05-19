using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class PhotonConnect : MonoBehaviourPunCallbacks
{
    private void Awake()
    {
        Debug.Log("Connecting to master server..");
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to master server");
        PhotonNetwork.JoinLobby();
        base.OnConnectedToMaster();
    }

    public override void OnJoinedLobby()
    {
        Debug.Log("Connected to lobby");
        SceneManager.LoadScene("Lobby");
        base.OnJoinedLobby();
    }
}
