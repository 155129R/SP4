using UnityEngine;
using System.Collections;

public class AlphaChangeTest : MonoBehaviour
{
    public SpriteRenderer sprite_;
    public float fadespeed = 1.0f;
    public float duration = 5.0f;
    public float minimum = 0f;
    public float maximum = 1f;
    private float startTime;
    private bool isNext = true;
    // Use this for initialization
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameStateManager.Instance.GetCharacterState() == GameStateManager.Character.POLLUX)
        {


            float t = (Time.time - startTime) / duration;
            float tem;

            if (!isNext)
            {

                tem = Mathf.SmoothStep(maximum, minimum, t);
                sprite_.color = new Color(1f, 1f, 1f, Mathf.SmoothStep(maximum, minimum, t / 2));
            }
            else
            {
                tem = Mathf.SmoothStep(minimum, maximum, t);
                sprite_.color = new Color(1f, 1f, 1f, Mathf.SmoothStep(minimum, maximum, t));

            }

            if (isNext)
            {
                if (tem > 0.9f)
                    isNext = false;
            }
        }
    }

}
