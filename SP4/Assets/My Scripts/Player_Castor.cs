using UnityEngine;
using System.Collections;

public class Player_Castor : Singleton<Player_Castor>
{
    private int m_Health;
    private int m_Mana;
    public float m_MovemoentSpeed = 5.0f;
    private GameObject character;

     
        
	// Use this for initialization
	void Start ()
    {
        character = GetComponent<GameObject>();
	}
	
	// Update is called once per frame
	void Update ()
    {
	
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

    public void HealPollux()//heals pollux
    {
        //currently empty
    }

    public void MoveForward()
    {
        character.transform.Translate(0, Time.deltaTime * m_MovemoentSpeed, 0);
    }
    public void MoveBackwards()
    {
        character.transform.Translate(0, -(Time.deltaTime * m_MovemoentSpeed), 0);
    }

    public void MoveRight()
    {
        character.transform.Translate((Time.deltaTime * m_MovemoentSpeed), 0, 0);
    }
    public void MoveLeft()
    {
        character.transform.Translate(-(Time.deltaTime * m_MovemoentSpeed), 0, 0);
    }


}
