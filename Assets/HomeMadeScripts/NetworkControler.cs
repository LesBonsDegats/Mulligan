using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkControler : MonoBehaviour
{
    private string gameversion = "0.1";
    // Use this for initialization
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings(gameversion);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Status: " + PhotonNetwork.connectionStateDetailed.ToString());
    }
    void OnJoinedLobby()
    {
        PhotonNetwork.JoinRandomRoom();
    }

    void OnPhotonRandomJoinFailed()
    {
        Debug.Log("Can't join the room");
        PhotonNetwork.CreateRoom(null);
    }

    void OnJoinedRoom()
    {
        Debug.Log("JoinedRoom");
    }
}