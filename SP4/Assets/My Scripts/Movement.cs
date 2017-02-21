using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class Movement : NetworkBehaviour {
    Transform myTransform;
    public float Speed = 5.0f;

	// Use this for initialization
	void Start () {
        myTransform = transform;
	}
	
	// Update is called once per frame
	void Update () {

        if (!isLocalPlayer)
        {
            return;
        }
        float x = Input.GetAxis("Horizontal") * Time.deltaTime * Speed;
        float y = Input.GetAxis("Vertical") * Time.deltaTime * Speed;


        myTransform.Translate(x, y  , 0);   

	}

    public override void OnStartLocalPlayer()
    {
        Camera.main.GetComponent<MoveCamera>().setTarget(gameObject.transform);
    }

}
