using UnityEngine;
using System.Collections;

public class Pixelcam : MonoBehaviour
{

    Camera cam;
    RenderTexture mainRT;
    public bool letterboxing;
    private int resX, resY;

    void Start ()
    {
        cam = Camera.main;
        resX = 512;
        resY = 288;
        if (letterboxing)
        {
            double meep = ( (double)resX / cam.aspect / 2D );
            double beep = ( 2D * meep - (double)resY );
            if (beep < 0D) {beep = 0D; }
            cam.orthographicSize = (float)meep;
            mainRT = new RenderTexture( resX, (int)( (double)resY + beep ), 24);
        }

        else
        {
            cam.orthographicSize = resY / 2;
            mainRT = new RenderTexture( (int)( cam.aspect * (double)resY ), resY, 24);
        }

        mainRT.filterMode = FilterMode.Point;
        cam.targetTexture = mainRT;

    }

    void OnPreRender()
    {
        cam.targetTexture = mainRT;
    }

    void OnPostRender()
    {
        cam.targetTexture = null;
        Graphics.Blit(mainRT, null as RenderTexture);
    }

}
