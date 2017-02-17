using UnityEngine;
using System.Collections;

public class PixelPerfectCamera : MonoBehaviour {

    public static float pixelToUnits = 1f;
    public static float scale = 1f;
    public float orthoFactor = 40f;
    public Vector2 nativeResolution = new Vector2(1440, 2560);
    //public Vector2 nativeResolution = new Vector2(Screen.width, Screen.height);
    void Awake()
    {
        var camera = GetComponent<Camera>();
        if (camera.orthographic)
        {
            var dir = Screen.height;
            var res = nativeResolution.y;

            scale = dir / res;
            pixelToUnits *= scale;

            camera.orthographicSize = (dir / orthoFactor) / pixelToUnits;
        }
    }
}
