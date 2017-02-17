using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class playerwalking : MonoBehaviour
{
    private Image man;
    public float movespeed;
 

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        float axisX = Input.GetAxis("Horizontal");
        float axisY = Input.GetAxis("Vertical");

        transform.Translate(new Vector3(axisX, axisY) * Time.deltaTime * movespeed);
    }

    public float getPlayerpositionX()
    {
        return transform.position.x;
    }

    public float getPlayerpositionY()
    {
        return transform.position.y;
    }

}
