using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectRender : MonoBehaviour
{
    SpriteRenderer imageComponent;
    public Sprite normalImg;
    public Sprite blindImg;

    //Alpha change stuff
    public float fadespeed = 1.0f;
    public float duration = 5.0f;
    public float minimum = 0f;
    public float maximum = 1f;
    private float startTime;
    private bool isNext = true;
    private bool isCollide = false;

    // Use this for initialization
    void Start ()
    {
        startTime = Time.time;
        imageComponent = GetComponent<SpriteRenderer>();
        if (GameStateManager.Instance.GetCharacterState()== GameStateManager.Character.CASTOR)
        {
            //NORMAL RENDER STUFF
            imageComponent.sprite = normalImg;
         
        }
        else if(GameStateManager.Instance.GetCharacterState() == GameStateManager.Character.POLLUX)
        {
            imageComponent.sprite = blindImg;
            imageComponent.color = new Color(1f, 1f, 1f, 0f);
        }
	}

    // Update is called once per frame
    void Update()
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

        if (isCollide)
            if (GameStateManager.Instance.GetCharacterState() == GameStateManager.Character.POLLUX)
            {

                float t = (Time.time - startTime) / duration;
                float tem;

                if (!isNext)
                {

                    tem = Mathf.SmoothStep(maximum, minimum, t/2);
                    imageComponent.color = new Color(1f, 1f, 1f, Mathf.SmoothStep(maximum, minimum, t/2));
                    if (tem <= 0f)
                    {
                        isNext = true;
                        isCollide = false;
                        startTime = Time.time;
                        Debug.Log("false");
                        
                    }


                }
                else
                {
                    tem = Mathf.SmoothStep(minimum, maximum, (t * 5f));
                    imageComponent.color = new Color(1f, 1f, 1f, Mathf.SmoothStep(minimum, maximum, t * 5f));
                    if (tem > 0.9f)
                        isNext = false;

                }

            }

    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
            if(!isCollide)
            isCollide = true;
    }
}
