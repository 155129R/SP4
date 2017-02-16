using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectRender : MonoBehaviour
{
    Image imageComponent;
    public Sprite normalImg;
    public Sprite blindImg;
	// Use this for initialization
	void Start ()
    {
        
	    if (GameStateManager.Instance.GetCharacterState()== GameStateManager.Character.CASTOR)
        {
            //NORMAL RENDER STUFF
            imageComponent.sprite = normalImg;
        }
        else if(GameStateManager.Instance.GetCharacterState() == GameStateManager.Character.POLLUX)
        {
            imageComponent.sprite = blindImg;
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (GameStateManager.Instance.GetCharacterState() == GameStateManager.Character.CASTOR)
        {
            //NORMAL RENDER STUFF
            imageComponent.sprite = normalImg;
        }
        else if (GameStateManager.Instance.GetCharacterState() == GameStateManager.Character.POLLUX)
        {
            imageComponent.sprite = blindImg;
        }
    }
}
