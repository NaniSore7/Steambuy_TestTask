using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;
using UnityEngine.UI;
using Photon.Pun.Simple;
using TMPro;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviourPunCallbacks
{
    [SerializeField] private TMP_InputField serverName;
    [SerializeField] private GameObject errorPanel;
    public void CreateRoom()
    {
        if (PhotonNetwork.IsConnected && serverName.text.Length > 0)
        {
            RoomOptions roomOpt = new RoomOptions();
            roomOpt.MaxPlayers = 4;
            PhotonNetwork.CreateRoom(serverName.text, roomOpt, TypedLobby.Default);

        }
        else
        {
            errorPanel.SetActive(true);
        }
    }

    public override void OnCreatedRoom()
    {
        Debug.Log("Successfully created room with name: " + PhotonNetwork.CurrentRoom.Name);
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        errorPanel.SetActive(true);
    }

    public void JoinRoom()
    {
        if (PhotonNetwork.IsConnected && serverName.text.Length > 0)
        {
            PhotonNetwork.JoinRoom(serverName.text);
        }
        else
        {
            errorPanel.SetActive(true);
        }
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Successfully joined room with name: " + PhotonNetwork.CurrentRoom.Name);
        PhotonNetwork.LoadLevel("Game");
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        errorPanel.SetActive(true);
    }

    public void LeaveRoomButton()
    {
        PhotonNetwork.LeaveRoom();
    }
    public override void OnLeftRoom()
    {
        PhotonNetwork.LoadLevel("Lobby");
    }
}
