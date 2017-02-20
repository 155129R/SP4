using UnityEngine;
using UnityEngine.Events;

public class MyInputs : MonoBehaviour {

    public float swipeSensitivity = 0.2f;
    public float minimumSwipeDist = 30.0f;

    public UnityEvent SwipeUp;
    public UnityEvent SwipeDown;
    public UnityEvent SwipeLeft;
    public UnityEvent SwipeRight;
    public UnityEvent Tap;
    
    private float timerForSwipe = 0.0f;
    private Vector3 onTouchPos;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
    void Update()
    {
        if (timerForSwipe <= swipeSensitivity)
                timerForSwipe += Time.deltaTime;
    }

    public void OnTouch()
    {
        onTouchPos = Input.mousePosition;
        timerForSwipe = 0.0f;
    }

    public void OnRelease()
    {
        Vector3 dir = Input.mousePosition - onTouchPos;

        if (dir.sqrMagnitude <= minimumSwipeDist)
        {//if tap
            Tap.Invoke();
        }
        else if (timerForSwipe <= swipeSensitivity)
        {//else if swipe
            if (Mathf.Abs(dir.y) > Mathf.Abs(dir.x))
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
