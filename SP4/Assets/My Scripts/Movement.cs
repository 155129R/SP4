using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class Movement : NetworkBehaviour {
    Transform myTransform;
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public float bulletSpeed = 6.0f;
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

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Fire();
            Debug.Log("test");
        }
	}

    void Fire()
    {
        GameObject bullet = (GameObject)Instantiate(bulletPrefab);
        bullet.transform.position = bulletSpawn.transform.position;
        bullet.transform.rotation = bulletSpawn.transform.rotation;

        //Add vel
        bullet.GetComponent<Rigidbody2D>().velocity = bullet.transform.up * bulletSpeed;

        Destroy(bullet, 1);
    }
    public override void OnStartLocalPlayer()
    {
        Camera.main.GetComponent<MoveCamera>().setTarget(gameObject.transform);
    }

}
