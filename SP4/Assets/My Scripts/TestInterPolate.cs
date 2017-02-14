using UnityEngine;
using System.Collections;
using UnityEngine.Networking;


public class TestInterPolate : NetworkBehaviour
{
    [SyncVar]
    private Vector3 syncPos;
    [SerializeField] Transform myTransform;
    public float lerpRate = 15;

    void FixedUpdate()
    {
        TransmitPosition();
        lerpPosition();
    }

    void lerpPosition()
    {
        if (!isLocalPlayer)
        {
            myTransform.position = Vector3.Lerp(myTransform.position, syncPos, Time.deltaTime * lerpRate);
        }
    }  
    [Command]
    void CmdPositionToServer(Vector3 pos)
    {
        syncPos = pos;
    }
    [ClientCallback]
    void TransmitPosition()
    {
        if (isLocalPlayer)
        {
            CmdPositionToServer(myTransform.position);
        }
    }

}   

