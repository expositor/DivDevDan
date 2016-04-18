using UnityEngine;
using System.Collections;

public class expcam : MonoBehaviour {

    Camera cam;
    RenderTexture mainRT;
    public bool letterboxing;
    private int resX, resY;

    void Start () {
        cam = Camera.main;
        resX = 512;
        resY = 288;
        if (letterboxing)
        {
        	if (resX <= resY * cam.aspect) {
        		//Wider/flatter than or equal to 16/9 - Increase width of render texture.
        		mainRT = new RenderTexture((int)(resY * cam.aspect), resY, 24);
        	} else {
        		//Thinner/taller than 16/9 - Increase orthographic size accordingly, increase height of render texture.
        		mainRT = new RenderTexture(resX, (int)(resX / cam.aspect), 24);
        		cam.orthographicSize = resX / cam.aspect / 2;
        	}
        	/*
            int meep = (int)( (double)resX / cam.aspect / 2D );
            int beep = 2 * meep - resY;
            if (beep < 0) { beep = 0; }
            cam.orthographicSize = meep;
            mainRT = new RenderTexture( resX, resY + beep, 24);
            */
        }
        else
        {
            cam.orthographicSize = resY / 2;
            mainRT = new RenderTexture( (int)( cam.aspect * (double)resY ), resY, 24);
        }
        mainRT.filterMode = FilterMode.Point;
        cam.targetTexture = mainRT;
    }

    void OnPreRender() {
        cam.targetTexture = mainRT;
    }

    void OnPostRender() {
        cam.targetTexture = null;
        Graphics.Blit(mainRT, null as RenderTexture);
    }

}
