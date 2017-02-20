using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class MoveCamera : NetworkBehaviour {

    public float speed = 4f;

    private Vector3 startPos;
    private bool moving;
    public Transform player;
    public Vector3 offset;
    Camera myCam;

    void Start()
    {
        myCam = GetComponent<Camera>();
        offset = transform.position - player.transform.position;        
    }
    private void FixedUpdate()
    {
            //if (!isLocalPlayer)
            //{
            //    myCam.enabled = false;
            //}
            //else
            //{
            //    myCam.enabled = true;
            //}  
        if (Input.GetMouseButtonDown(1))
        {
            startPos = Input.mousePosition;
            moving = true;
        }
        if(Input.GetMouseButtonUp(1) && moving)
        {
            moving = false;
        }
        if(moving)
        {
            Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - startPos);
            Vector3 move = new Vector3(pos.x * speed, pos.y * speed, 0);
            transform.Translate(move, Space.Self);
        }
    }

    private void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
    public void setTarget(Transform target)
    {
        player = target;
    }
}
