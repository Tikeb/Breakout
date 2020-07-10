using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public SpriteRenderer backgroundRenderer;
    public SpriteRenderer topWallRenderer;
    public SpriteRenderer ceilingRenderer;

    public GameObject leftMenuItems;

    void Start()
    {
        SetupScreen();
        SetupCanvas();
    }

    private void SetupScreen()
    {
        float screenRatio = (float)Screen.width / (float)Screen.height;
        float targetRatio = backgroundRenderer.bounds.size.x / backgroundRenderer.bounds.size.y;

        if (screenRatio >= targetRatio)
        {
            Camera.main.orthographicSize = backgroundRenderer.bounds.size.y / 2;
        }
        else
        {
            float differenceInSize = targetRatio / screenRatio;
            Camera.main.orthographicSize = backgroundRenderer.bounds.size.y / 2 * differenceInSize;
        }
    }

    private void SetupCanvas()
    {
        /*
            | y
            |
            |
     --------------- x
            |
            |
            |
         */

        var ceiling = ceilingRenderer.transform.localPosition.y; //4.95
        var top = topWallRenderer.transform.localPosition.y; //4.27
        var blah = top;

        print($"Ceiling: {ceiling}");
        print($"Top: {top}");
        print($"Menu: {leftMenuItems.transform.localPosition.y}");

        //leftMenuItems.transform.localPosition = new Vector3(leftMenuItems.transform.localPosition.x, top * 100);

    }
}
