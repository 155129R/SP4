using UnityEngine;
using System.Collections;

public class TestEnemy : MonoBehaviour {
    int m_Health = 10;
	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    public void TakeDamage()
    {
        m_Health -= 2;
        Debug.Log("Hit");
    }
}
