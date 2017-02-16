using UnityEngine;
using System.Collections;

public class Player_Pollux : MonoBehaviour
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

                ObjectList[count].GetComponent<TestEnemy>().TakeDamage();
            }
            count += 1;
        }
    }

    void MoveForward()
    {
        character.transform.Translate(0, Time.deltaTime * m_MovementSpeed, 0);
    }
    void MoveBackwards()
    {
        character.transform.Translate(0, -(Time.deltaTime * m_MovementSpeed), 0);
    }

    public void MoveRight()
    {
        character.transform.Translate((Time.deltaTime * m_MovementSpeed), 0, 0);
    }
    public void MoveLeft()
    {
        character.transform.Translate(-(Time.deltaTime * m_MovementSpeed), 0, 0);
    }
}
