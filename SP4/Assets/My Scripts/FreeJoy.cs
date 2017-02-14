using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Events;

public class FreeJoy : MonoBehaviour{

    public UnityEvent SwipeUp;
    public UnityEvent SwipeDown;
    public UnityEvent SwipeLeft;
    public UnityEvent SwipeRight;
    public float swipeSensitivity = 0.2f;

    public Image joyBG;
    public Image joyThumb;
    public float maxLength = 5.0f;

    private float timerForSwipe = 0.0f;
    private Vector3 dir;
    private bool active;

	// Use this for initialization
	void Start () {
        timerForSwipe = 0.0f;
        active = false;
        joyBG.enabled =  false;
        joyThumb.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
        if(active)
        {
            if (timerForSwipe <= swipeSensitivity)
                timerForSwipe += Time.deltaTime;

            dir = Input.mousePosition - joyBG.rectTransform.position;
            float analogLength = dir.magnitude;

            if (analogLength > maxLength)
                analogLength = maxLength;

            joyThumb.rectTransform.localPosition = dir.normalized * analogLength;
        }
        else
        {
            dir.Set(0, 0, 0);
        }
	}

    public Vector3 GetInput()
    {
        return dir.normalized;
    }

    public void OnTouch()
    {
        active = true;
        joyBG.rectTransform.position = Input.mousePosition;
        joyBG.enabled = true;
        joyThumb.enabled = true;
        timerForSwipe = 0.0f;
    }

    public void OnRelease()
    {
        active = false;
        joyBG.enabled = false;
        joyThumb.enabled = false;

        if (timerForSwipe <= swipeSensitivity && dir.sqrMagnitude != 0)
        {
            if(Mathf.Abs(dir.y) > Mathf.Abs(dir.x))
            {//vertical swipe
                if (dir.y > 0)
                    SwipeUp.Invoke();
                else
                    SwipeDown.Invoke();
            }
            else
            {//horizontal swipe
                if (dir.x > 0)
                    SwipeRight.Invoke();
                else
                    SwipeLeft.Invoke();
            }
        }
    }
}
