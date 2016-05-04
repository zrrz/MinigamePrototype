using UnityEngine;
using System;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Networking.Match;
using UnityEngine.Networking.NetworkSystem;
using UnityEngine.Networking.Types;
using UnityEngine.SceneManagement;

public class ConnectionHandler : MonoBehaviour {

//    [SerializeField] LogFilter.FilterLevel m_LogLevel = (LogFilter.FilterLevel)LogFilter.Info;
//    [SerializeField] string m_NetworkAddress = "localhost";
//    [SerializeField] int m_NetworkPort = 7777;
//
//    public static ConnectionHandler singleton;
//
//    public NetworkClient client;
//
//    void Awake()
//    {
//        InitializeSingleton();
//    }
//
//    void InitializeSingleton()
//    {
//        if (singleton != null && singleton == this)
//        {
//            return;
//        }
//
//        // do this early
//        LogFilter.currentLogLevel = (int)m_LogLevel;
//
////        if (m_DontDestroyOnLoad)
////        {
//        if (singleton != null)
//        {
//            if (LogFilter.logDev) { Debug.Log("Multiple NetworkManagers detected in the scene. Only one NetworkManager can exist at a time. The duplicate NetworkManager will not be used."); }
//            Destroy(gameObject);
//            return;
//        }
//        if (LogFilter.logDev) { Debug.Log("NetworkManager created singleton (DontDestroyOnLoad)"); }
//        singleton = this;
//        DontDestroyOnLoad(gameObject);
////        }
////        else
////        {
////            if (LogFilter.logDev) { Debug.Log("NetworkManager created singleton (ForScene)"); }
////            singleton = this;
////        }
//    }
//
//	// Use this for initialization
//	void Start () {
//	
//	}
//	
//	// Update is called once per frame
//	void Update () {
//	
//	}
//
//    public virtual NetworkClient StartHost()
//    {
//        OnStartHost();
//        if (StartServer())
//        {
//            var localClient = ConnectLocalClient();
//            OnServerConnect(localClient.connection);
//            OnStartClient(localClient);
//            return localClient;
//        }
//        return null;
//    }
//
//    bool StartServer(MatchInfo info, ConnectionConfig config, int maxConnections)
//    {
//        InitializeSingleton();
//
//        OnStartServer();
//
////        if (m_RunInBackground)
//        Application.runInBackground = true;
//
//        NetworkCRC.scriptCRCCheck = true;
//        NetworkServer.useWebSockets = false;
//
////        if (m_GlobalConfig != null)
////        {
//        NetworkTransport.Init();//(m_GlobalConfig);
////        }
//
////        // passing a config overrides setting the connectionConfig property
////        if (m_CustomConfig && m_ConnectionConfig != null && config == null)
////        {
////            m_ConnectionConfig.Channels.Clear();
////            foreach (var c in m_Channels)
////            {
////                m_ConnectionConfig.AddChannel(c);
////            }
////            NetworkServer.Configure(m_ConnectionConfig, m_MaxConnections);
////        }
//
//        if (config != null)
//        {
//            NetworkServer.Configure(config, maxConnections);
//        }
//
//        if (info != null)
//        {
//            if (!NetworkServer.Listen(info, m_NetworkPort))
//            {
//                if (LogFilter.logError) { Debug.LogError("StartServer listen failed."); }
//                return false;
//            }
//        }
//        else
//        {
//            if (m_ServerBindToIP && !string.IsNullOrEmpty(m_ServerBindAddress))
//            {
//                if (!NetworkServer.Listen(m_ServerBindAddress, m_NetworkPort))
//                {
//                    if (LogFilter.logError) { Debug.LogError("StartServer listen on " + m_ServerBindAddress + " failed."); }
//                    return false;
//                }
//            }
//            else
//            {
//                if (!NetworkServer.Listen(m_NetworkPort))
//                {
//                    if (LogFilter.logError) { Debug.LogError("StartServer listen failed."); }
//                    return false;
//                }
//            }
//        }
//
//        // this must be after Listen(), since that registers the default message handlers
//        RegisterServerMessages();
//
//        if (LogFilter.logDebug) { Debug.Log("NetworkManager StartServer port:" + m_NetworkPort); }
//        isNetworkActive = true;
//
//        // Only change scene if the requested online scene is not blank, and is not already loaded
//        string loadedSceneName = SceneManager.GetSceneAt(0).name;
//        if (m_OnlineScene != "" && m_OnlineScene != loadedSceneName && m_OnlineScene != m_OfflineScene)
//        {
//            ServerChangeScene(m_OnlineScene);
//        }
//        else
//        {
//            NetworkServer.SpawnObjects();
//        }
//        return true;
//    }
//
//    NetworkClient ConnectLocalClient()
//    {
//        if (LogFilter.logDebug) { Debug.Log("NetworkManager StartHost port:" + m_NetworkPort); }
//        m_NetworkAddress = "localhost";
//        client = ClientScene.ConnectLocalServer();
//        RegisterClientMessages(client);
//
//        return client;
//    }
//
//    public virtual void OnStartHost()
//    {
//    }
//
//    public virtual void OnStartServer()
//    {
//    }
//
//    public virtual void OnServerConnect(NetworkConnection conn)
//    {
//    }
//
//    public virtual void OnStartClient(NetworkClient client)
//    {
//    }
}
