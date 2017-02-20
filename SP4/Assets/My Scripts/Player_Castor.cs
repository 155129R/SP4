using UnityEngine;
using System.Collections;

public class Player_Castor : Singleton<Player_Castor>
{
    private int m_Health;
    private int m_Mana;
    public float m_MovementSpeed = 25.0f;
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

    public void UpdatePosition(float xInput, float yInput)
    {
        transform.Translate(new Vector3(xInput, yInput) * Time.deltaTime * m_MovementSpeed);
    }


}
