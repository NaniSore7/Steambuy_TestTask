using Photon.Pun;
using Photon.Pun.Simple;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsSpawner : MonoBehaviour
{
    public GameObject coin;
    [SerializeField] private float amountOfCoins = 10;

    [SerializeField] private float minX, minY, maxX, maxY;

    void Start()
    {
        if (!PhotonNetwork.IsMasterClient)
        {
            return;
        }
        for (int i = 0; i < amountOfCoins; i++)
        {
            Vector2 coinSpawnRange = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
            PhotonNetwork.Instantiate(coin.name, coinSpawnRange, Quaternion.identity);
        }
    }
}
