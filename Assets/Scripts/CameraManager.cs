using UnityEngine;

public class CameraManager : MonoBehaviour
{
    void Start()
    {
        print("hello there");


        SetupScreen();
        /*// set the desired aspect ratio (the values in this example are
        // hard-coded for 16:9, but you could make them into public
        // variables instead so you can set them at design time)
        var targetaspect = 16.0f / 9.0f;

        // determine the game window's current aspect ratio
        var windowaspect = (float)Screen.width / (float)Screen.height;

        // current viewport height should be scaled by this amount
        var scaleheight = windowaspect / targetaspect;

        // obtain camera component so we can modify its viewport
        var camera = GetComponent<Camera>();

        // if scaled height is less than current height, add letterbox
        if (scaleheight < 1.0f)
        {
            Rect rect = camera.rect;

            rect.width = 1.0f;
            rect.height = scaleheight;
            rect.x = 0;
            rect.y = (1.0f - scaleheight) / 2.0f;

            camera.rect = rect;
        }
        else // add pillarbox
        {
            float scalewidth = 1.0f / scaleheight;

            Rect rect = camera.rect;

            rect.width = scalewidth;
            rect.height = 1.0f;
            rect.x = (1.0f - scalewidth) / 2.0f;
            rect.y = 0;

            camera.rect = rect;
        }*/
    }

    private void SetupScreen()
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

        var width = Screen.width;
        var height = Screen.height;

        print(width);

        //var blah = (width / 100f) / 2f;

        //GameObject.Find("left-wall").GetComponent<SpriteRenderer>().transform.position = new Vector3(-blah, 0);
        
    }
}
