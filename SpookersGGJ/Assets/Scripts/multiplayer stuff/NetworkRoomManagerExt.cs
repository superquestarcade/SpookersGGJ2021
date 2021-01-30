using UnityEngine;
using UnityEngine.SceneManagement;
using Mirror;
using System;
using System.Collections.Generic;
[AddComponentMenu("")]
    public class NetworkRoomManagerExt : NetworkRoomManager
    {
        [Header("Spawner Setup")]
        [Tooltip("Reward Prefab for the Spawner")]
        public GameObject rewardPrefab;

        [Range(0, 1)]
        public int teamID;

        public List<NetworkRoomPlayerExt> RoomPlayers { get; } = new List<NetworkRoomPlayerExt>();

    /// <summary>
    /// This is called on the server when a networked scene finishes loading.
    /// </summary>
    /// <param name="sceneName">Name of the new scene.</param>
    public override void OnRoomServerSceneChanged(string sceneName)
        {
            // spawn the initial batch of Rewards
            if (sceneName == GameplayScene)
            {
               // Spawner.InitialSpawn();
            }
        }

        public override void OnServerAddPlayer(NetworkConnection conn)
        {
            // increment the index before adding the player, so first player starts at 1
            clientIndex++;

            if (IsSceneActive(RoomScene))
            {
                if (roomSlots.Count == maxConnections)
                    return;

                allPlayersReady = false;

                GameObject newRoomGameObject = OnRoomServerCreateRoomPlayer(conn);
                if (newRoomGameObject == null)
                    newRoomGameObject = Instantiate(roomPlayerPrefab.gameObject, Vector3.zero, Quaternion.identity);

                NetworkServer.AddPlayerForConnection(conn, newRoomGameObject);
            }
            else
                OnRoomServerAddPlayer(conn);
        }


    /// <summary>
    /// Called on the server when a client is ready.
    /// <para>The default implementation of this function calls NetworkServer.SetClientReady() to continue the network setup process.</para>
    /// </summary>
    public override void OnRoomClientEnter() {
        if(teamID == 0)
        {
            teamID = 1;
        }
        else
        {
            teamID = 0;
        }

        foreach (NetworkRoomPlayer player in roomSlots)
            if (player != null)
            {
                player.GetComponent<player_properties>().teamID = teamID;
                if (teamID == 0)
                {
                    teamID = 1;
                }
                else
                {
                    teamID = 0;
                }
            }
    }

    /// <summary>
    /// This is a hook to allow custom behaviour when the game client exits the room.
    /// </summary>
    public override void OnRoomClientExit() {
        if (teamID == 0)
        {
            teamID = 1;
        }
        else
        {
            teamID = 0;
        }

        foreach (NetworkRoomPlayer player in roomSlots)
            if (player != null)
            {
                player.GetComponent<player_properties>().teamID = teamID;
                if (teamID == 0)
                {
                    teamID = 1;
                }
                else
                {
                    teamID = 0;
                }
            }
    }

    public void StartGame()
    {
        Debug.Log("start");
        if (SceneManager.GetActiveScene().name == "RoomScene")
        {
            if (!IsReadyToStart()) { return; }
            ServerChangeScene(GameplayScene);
        }
    }

    public void NotifyPlayersOfReadyState()
    {
        RoomPlayers[0].IsLeader = true;
        IsReadyToStart();

        foreach (var player in RoomPlayers)
        {
            player.HandleReadyToStart(IsReadyToStart());
        }


    }

    public bool IsReadyToStart()
    {
        if (numPlayers < minPlayers) { return false; }

        foreach (var player in RoomPlayers)
        {
            if (!player.IsReady) { return false; }
        }

        return true;
    }

    public override void OnServerDisconnect(NetworkConnection conn)
    {
        if (conn.identity != null)
        {
            var player = conn.identity.GetComponent<NetworkRoomPlayerExt>();

            RoomPlayers.Remove(player);

            NotifyPlayersOfReadyState();
        }

        base.OnServerDisconnect(conn);
    }


    public override void OnStopServer()
    {
        RoomPlayers.Clear();
    }
    /// <summary>
    /// Called just after GamePlayer object is instantiated and just before it replaces RoomPlayer object.
    /// This is the ideal point to pass any data like player name, credentials, tokens, colors, etc.
    /// into the GamePlayer object as it is about to enter the Online scene.
    /// </summary>
    /// <param name="roomPlayer"></param>
    /// <param name="gamePlayer"></param>
    /// <returns>true unless some code in here decides it needs to abort the replacement</returns>
    public override bool OnRoomServerSceneLoadedForPlayer(NetworkConnection conn, GameObject roomPlayer, GameObject gamePlayer)
        {   
            player_properties playerProp = gamePlayer.GetComponent<player_properties>();
            playerProp.teamID = roomPlayer.GetComponent<player_properties>().teamID;
            NetworkServer.Destroy(roomPlayer);
            return true;
        }

        public override void OnRoomStopClient()
        {
            // Demonstrates how to get the Network Manager out of DontDestroyOnLoad when
            // going to the offline scene to avoid collision with the one that lives there.
            if (gameObject.scene.name == "DontDestroyOnLoad" && !string.IsNullOrEmpty(offlineScene) && SceneManager.GetActiveScene().path != offlineScene)
                SceneManager.MoveGameObjectToScene(gameObject, SceneManager.GetActiveScene());

            base.OnRoomStopClient();
        }

        public override void OnRoomStopServer()
        {
            // Demonstrates how to get the Network Manager out of DontDestroyOnLoad when
            // going to the offline scene to avoid collision with the one that lives there.
            if (gameObject.scene.name == "DontDestroyOnLoad" && !string.IsNullOrEmpty(offlineScene) && SceneManager.GetActiveScene().path != offlineScene)
                SceneManager.MoveGameObjectToScene(gameObject, SceneManager.GetActiveScene());

            base.OnRoomStopServer();
        }

        /*
            This code below is to demonstrate how to do a Start button that only appears for the Host player
            showStartButton is a local bool that's needed because OnRoomServerPlayersReady is only fired when
            all players are ready, but if a player cancels their ready state there's no callback to set it back to false
            Therefore, allPlayersReady is used in combination with showStartButton to show/hide the Start button correctly.
            Setting showStartButton false when the button is pressed hides it in the game scene since NetworkRoomManager
            is set as DontDestroyOnLoad = true.
        */

        bool showStartButton;

        public override void OnRoomServerPlayersReady()
        {
            // calling the base method calls ServerChangeScene as soon as all players are in Ready state.
#if UNITY_SERVER
            base.OnRoomServerPlayersReady();
#else
            showStartButton = true;
#endif
        }

        public override void OnGUI()
        {
            base.OnGUI();

            if (allPlayersReady && showStartButton && GUI.Button(new Rect(150, 300, 120, 20), "START GAME"))
            {
                // set to false to hide it in the game scene
                showStartButton = false;

                ServerChangeScene(GameplayScene);
            }
        }
    }

