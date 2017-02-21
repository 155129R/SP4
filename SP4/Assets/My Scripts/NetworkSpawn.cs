using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class NetworkSpawn : NetworkBehaviour{
    public GameObject Pollux;
    public GameObject Castor;
	// Use this for initialization
	void Start () {
        if (Network.isServer)
            Debug.Log("HELLO");
        //if (isServer)
        //{
        //    Instantiate(Pollux, Pollux.transform.position, Quaternion.identity);
        //    GameStateManager.Instance.SetCharacter(GameStateManager.Character.POLLUX);
        //    Debug.Log("tasd");
         
        //}
        //else
        //{
        //   Instantiate(Castor, Castor.transform.position, Quaternion.identity);

        //    GameStateManager.Instance.SetCharacter(GameStateManager.Character.CASTOR);

        //}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
