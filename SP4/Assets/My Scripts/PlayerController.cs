using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    //public float attackForce = 5.0f;
    //public float attackSpeed = 0.5f;
    public float acceleration = 30.0f;
    public float maxSpeed = 10.0f;
    public FreeJoy freeJoy;
    private Rigidbody2D rb;

    private float attackSpeedTimer = 0.0f;
    private float attackForceValue;
    private Vector2 front = new Vector2(0, 1);
    //public GameObject test;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        float dt = Time.deltaTime;
  
                //if not moving, brake
        if(!Move(freeJoy.GetInput(), dt))
        {
            rb.velocity.Set(0, 0); //doesnt seem to be working for me
            //Vector2 zeroVel = new Vector2();
           
        }

       if(Input.GetKeyDown("space"))
        {
            Attack();
        }
	}

    public void Attack()
    {
        int count = 0;
        // TestEnemy[] EnemyList = FindObjectsOfType(typeof (TestEnemy));
        GameObject[] ObjectList = GameObject.FindGameObjectsWithTag("TestEnemy");
        foreach (GameObject Object in ObjectList)
        {
            
            if(Vector3.Distance( ObjectList[count].transform.position, transform.position)< 1000000)
            {
                //Object is TestEnemy
             
                ObjectList[count].GetComponent<TestEnemy>().TakeDamage();
            }
            count += 1;
        }
    }


    //if moving, return true
    private bool Move(Vector3 dir, float dt)
    {
        if (dir.sqrMagnitude == 0)
        {
            //Debug.Log("NO");
            return false;
        }
        //Debug.Log("YES");

        front = dir.normalized;

        Vector2 vel = rb.velocity;
        vel.x += dir.x * acceleration * dt;
        vel.y += dir.y * acceleration * dt;

        if(vel.sqrMagnitude > maxSpeed * maxSpeed)
            vel = vel.normalized * maxSpeed;

        rb.velocity = vel;

        return true;
    }

    private float lerp(float v0, float v1, float t)
    {
        return (1 - t) * v0 + t * v1;
    }
}
