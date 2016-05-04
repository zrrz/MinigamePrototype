using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class GameManager : NetworkBehaviour {

    static GameManager instance;

    [SyncVar]
    public int m_spawnNumber = 0;

    public static GameManager Instance {
        get {
            return instance;
        }
    }

    void Awake()
    {
        InitializeSingleton();
    }

    void InitializeSingleton()
    {
        if (instance != null && instance == this)
        {
            return;
        }
            
        if (instance != null)
        {
            if (LogFilter.logDev) { Debug.Log("Multiple NetworkManagers detected in the scene. Only one NetworkManager can exist at a time. The duplicate NetworkManager will not be used."); }
            Destroy(gameObject);
            return;
        }
        if (LogFilter.logDev) { Debug.Log("NetworkManager created singleton (DontDestroyOnLoad)"); }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

//	void Start () {
//	
//	}
//	
//	void Update () {
//	
//	}
}
