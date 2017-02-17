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
    public float fadespeed = 3.0f;
    public float duration = 10f;
    public float minimum = 0f;
    public float maximum = 1f;
    private float startTime;
    private bool isNext = true;
    private bool isCollide = false;
    private bool isUntouched = true;

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
        //if (GameStateManager.Instance.GetCharacterState() == GameStateManager.Character.CASTOR)
        //{
        //    //NORMAL RENDER STUFF
        //    imageComponent.sprite = normalImg;
        //}
        //else if (GameStateManager.Instance.GetCharacterState() == GameStateManager.Character.POLLUX)
        //{
        //    imageComponent.sprite = blindImg;
        //}

            if (GameStateManager.Instance.GetCharacterState() == GameStateManager.Character.POLLUX)
            {

                float t = (Time.time - startTime) / duration;
                float tem;

                if (!isCollide && !isUntouched)
                {

                    tem = Mathf.SmoothStep(maximum, minimum, t);
                    imageComponent.color = new Color(1f, 1f, 1f, Mathf.SmoothStep(maximum, minimum, t *2f));
                    //if (tem <= 0f)
                    //{
                    //    isNext = true;
                    //    isCollide = false;
                    //    startTime = Time.time;
                        
                    //}


                }
                if(isCollide)
                {
                    tem = Mathf.SmoothStep(minimum, maximum, (t));
                    imageComponent.color = new Color(1f, 1f, 1f, Mathf.SmoothStep(minimum, maximum, t * 8f));
                    if (tem > 0.9f)
                        isNext = false;

                }

            }

    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            isUntouched = false;
            isCollide = true;
            startTime = Time.time;
        }
            
    }

    void OnCollisionExit2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            isCollide = false;
            startTime = Time.time;
        }

               
    }

}
