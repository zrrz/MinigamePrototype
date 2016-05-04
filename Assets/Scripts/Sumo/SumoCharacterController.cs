using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class SumoCharacterController : NetworkBehaviour {
   
//    public Transform m_spawnPositions;

    Rigidbody m_rigidBody;
    public float m_speed = 5f;

    Vector3 m_spawnPosition;

    float grounded = 0f;

	void Start () {
        if (!isLocalPlayer)
            return;

		foreach(Renderer rend in GetComponentsInChildren<Renderer>()) {
			rend.material.color = Color.blue;
		}
        
        m_rigidBody = GetComponent<Rigidbody>();
        Debug.Log("Spawning at " + Network.connections.Length);
        m_spawnPosition = transform.position;// GameObject.Find("SpawnPositions").transform.GetChild(GameManager.Instance.m_spawnNumber++).position;
        Reset();
    }
    
    void Update () {
        if (!isLocalPlayer)
            return;

        if (grounded < 0f)
        {
            //TODO switch to hard angle turning like a car
            Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
            m_rigidBody.AddForce(direction * m_speed, ForceMode.Force);
        }
        else
        {
            grounded -= Time.deltaTime;
        }
	}

    void Reset() {
        grounded = 0.3f;
//        transform.rotation = Vector3.zero;
        transform.LookAt(Vector3.zero);
        transform.position = m_spawnPosition;
        m_rigidBody.velocity = m_rigidBody.angularVelocity = Vector3.zero;
    }

    void OnCollisionEnter(Collision col) {
        if (col.gameObject.tag == "OutOfBounds")
        {
            Reset();
        }
        if (col.gameObject.GetComponent<SumoCharacterController>() != null)
        {
            Vector3 dir = transform.position - col.contacts[0].point;
            col.gameObject.GetComponent<SumoCharacterController>().KnockBack(dir);
        }
    }

    void KnockBack(Vector3 dir) {
        float strength = 200f;
        Vector3 amount = dir * strength;

        if (isClient)
        {
            CmdKnockBack(amount);
        }
        else if (isServer)
        {
            RpcKnockBack(amount);
        }

    }

    [Command]
    void CmdKnockBack(Vector3 amount) {
        m_rigidBody.AddForce(amount);
    }

    [ClientRpc]
    void RpcKnockBack(Vector3 amount) {
        m_rigidBody.AddForce(amount);
    }

//    void OnCollisionStay(Collision col) {
//        if (col.gameObject.layer == "Ground")
//        {
//            grounded = true;
//        }
//    }
//
//    void OnCollisionExit() {
//        if (col.gameObject.layer == "Ground")
//        {
//            grounded = true;
//        }
//    }
}
