using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using System;
using UnityEditor.XR;
using Random = UnityEngine.Random;

public class networking : MonoBehaviourPunCallbacks
{
    private bool isConnected = false;

    private GameObject spawnedPlayerPrefab;

    public int randomint;

    public void ConnectedToServer()

    {

        if (!isConnected)

        {

            PhotonNetwork.ConnectUsingSettings(); // This code connects to the Photon server once the Unity scene starts

        }



    }



    public override void OnConnectedToMaster()

    {

        base.OnConnectedToMaster();

        PhotonNetwork.NickName = "" + randomint;
        RoomOptions roomOptions = new RoomOptions();

        roomOptions.MaxPlayers = 10;

        roomOptions.IsVisible = true;

        roomOptions.IsOpen = true;

        PhotonNetwork.JoinOrCreateRoom("Main Room", roomOptions, TypedLobby.Default);



        isConnected = true;



    }



    public override void OnJoinedLobby()

    {

        PhotonNetwork.LoadLevel(0); // Here you load you level
        PhotonNetwork.Instantiate("Player", transform.position, transform.rotation);

        // This callback happens when players joinig the general lobby

    }

    void Start()
    {
        ConnectToServer();
        randomint = Random.Range(0, 9999999);
    }

    void ConnectToServer()

    {

        PhotonNetwork.ConnectUsingSettings();

        Debug.Log("Trying to connect to server...");

    }

    IEnumerator waiter()
    {
        yield return new WaitForSeconds(5);


    }

    public void InitializeRoom(int room)

    {


    }



    public override void OnJoinedRoom()

    {

        base.OnJoinedRoom();
        spawnedPlayerPrefab = PhotonNetwork.Instantiate("Player", transform.position, transform.rotation);


    }



    public override void OnPlayerEnteredRoom(Player newPlayer)

    {

        base.OnPlayerEnteredRoom(newPlayer);

    }
    public override void OnLeftRoom()

    {

        base.OnLeftRoom();

        PhotonNetwork.Destroy(spawnedPlayerPrefab);

    }

}

