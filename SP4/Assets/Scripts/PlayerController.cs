using UnityEngine;
using System.Collections;

public class PlayerController : Singleton<PlayerController>
{
    protected PlayerController()
    {

    }

    

	// Use this for initialization
	void Start ()
    {
	   
	}
	
	// Update is called once per frame
	void Update ()
    {
        ControllerUpdate();
    }

    private void ControllerUpdate()
    {
        float axisX = Input.GetAxis("Horizontal");
        float axisY = Input.GetAxis("Vertical");

        if (GameStateManager.Instance.GetCharacterState() == GameStateManager.Character.CASTOR)
        {
            Player_Castor.Instance.UpdatePosition(axisX, axisY);
        }
        else if (GameStateManager.Instance.GetCharacterState() == GameStateManager.Character.POLLUX)
        {
            Player_Pollux.Instance.UpdatePosition(axisX, axisY);
        }

    }
}
