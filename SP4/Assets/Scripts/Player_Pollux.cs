using UnityEngine;
using System.Collections;

public class Player_Pollux : Singleton<Player_Pollux>
{
    private int m_Health;
    private int m_Mana;
    public float m_MovementSpeed = 5.0f;
    private GameObject character;

    // Use this for initialization
    void Start ()
    {
        character = GetComponent<GameObject>();
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if(Input.GetKeyDown("space"))
        {
            Attack();
        }
	}
    public int GetHealth()
    {
        return m_Health;
    }
    public void SetHealth(int health)
    {
        m_Health = health;
    }

    public int GetMana()
    {
        return m_Mana;
    }

    public void Attack()//heals pollux
    {
        int count = 0;
        // TestEnemy[] EnemyList = FindObjectsOfType(typeof (TestEnemy));
        GameObject[] ObjectList = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject Object in ObjectList)
        {

            if (Vector3.Distance(ObjectList[count].transform.position, transform.position) < 1000000)
            {
                //Object is TestEnemy

                //ObjectList[count].GetComponent<Unit>().TakeDamage();
            }
            count += 1;
        }
    }

   public void UpdatePosition(float xInput, float yInput)
    {
        transform.Translate(new Vector3(xInput, yInput) * Time.deltaTime * m_MovementSpeed);
    }
}
