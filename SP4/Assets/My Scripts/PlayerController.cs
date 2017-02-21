using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour
{

    public float attackForce = 5.0f;
    public float attackSpeed = 0.5f;
    public float acceleration = 30.0f;
    public float maxSpeed = 10.0f;
    public FreeJoy freeJoy;
    private Rigidbody2D rb;

    private float attackSpeedTimer = 0.0f;
    private float attackForceValue;
    private Vector2 front = new Vector2(0, 1);
    private Vector2 vel;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        if (isLocalPlayer)
        {
            freeJoy = GameObject.Find("FreeJoy").GetComponent<FreeJoy>();
            //GameObject.Find("MainCamera").GetComponent<Camera>().GetComponent<MoveCamera>().player = this.gameObject.transform;
        }
	}
	
	// Update is called once per frame
	void Update () {
  
                //if not moving, brake
        if(!Move(freeJoy.GetInput(), Time.deltaTime))
        {
            // rb.velocity.Set(0, 0); //doesnt seem to be working for me
            //Debug.Log("NO");

            Vector2 zeroVel = new Vector2();
            rb.velocity = zeroVel;

        }

        if(attackForce > 0.0f)
        {
            rb.velocity += front * attackForceValue;
            attackForceValue = lerp(attackForceValue, 0, 5 * Time.deltaTime);
        }
       // Debug.Log(rb.velocity);
        
        if (attackSpeedTimer > 0.0f)
            attackSpeedTimer -= Time.deltaTime;
	}

    public void Attack()
    {
        if (attackSpeedTimer <= 0.0f)
        {
            attackSpeedTimer = attackSpeed;
            attackForceValue = attackForce;
        }
    }


    //if moving, return true
    private bool Move(Vector3 dir, float dt)
    {
        if (dir.sqrMagnitude == 0)
        {
            return false;
        }
        

        front = dir.normalized;

        vel = rb.velocity;
        vel.x += dir.x * acceleration * Time.deltaTime;
        vel.y += dir.y * acceleration * Time.deltaTime;

        if(vel.sqrMagnitude > maxSpeed * maxSpeed)
            vel = vel.normalized * maxSpeed;
        
        rb.velocity = vel;
        Debug.Log(this.transform.position);
        return true;
    }

    private float lerp(float v0, float v1, float t)
    {
        return (1 - t) * v0 + t * v1;
    }
    public override void OnStartLocalPlayer()
    {
        Camera.main.GetComponent<MoveCamera>().setTarget(gameObject.transform);
    }
}
