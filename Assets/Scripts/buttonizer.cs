using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

public class buttonizer : MonoBehaviour
{
    private Transform buttonCanvas;
    private Transform renderCanvas;

    void bloop(Button button)
    {
        button.onClick.Invoke();
    }

	void Start ()
	{

	    foreach (Transform child in transform)
        {
            if (child.name.Equals("ButtonCanvas")) { buttonCanvas = child; }
        }

	    foreach (Transform child in transform.parent)
        {
            if (child.name.Equals("RenderCanvas (STUFF GOES IN HERE)")) { renderCanvas = child; }
        }

        List<Transform> buttonList = new List<Transform>();
        foreach (Transform child in renderCanvas)
        {
            if (child.GetComponent<Button>() != null) { buttonList.Add(child); }
        }

        foreach (Transform thing in buttonList)
        {
            RectTransform rt =  thing.GetComponent<RectTransform>();
            Button bu = thing.GetComponent<Button>();

            GameObject spawn = new GameObject("spawn - " + thing.name, typeof(RectTransform));
            spawn.AddComponent<CanvasRenderer>();

            spawn.transform.SetParent(buttonCanvas, false);

            Image sim = spawn.AddComponent<Image>();
            sim.preserveAspect = true;
            sim.color = Color.clear;

            RectTransform srt = spawn.GetComponent<RectTransform>();
            srt.anchorMin = rt.anchorMin;
            srt.anchorMax = rt.anchorMax;
            srt.sizeDelta = rt.sizeDelta;
            srt.localScale = rt.localScale;
            // srt.localPosition = rt.localPosition;
            srt.eulerAngles = rt.eulerAngles;
            srt.anchoredPosition = rt.anchoredPosition;
            // srt.anchorMin = new Vector2(1,0);
            // srt.anchorMax = new Vector2(0,1);

            Button sbu = spawn.AddComponent<Button>();
            sbu.transition = bu.transition;
            sbu.targetGraphic = bu.targetGraphic;

            Sprite ssp = bu.spriteState.pressedSprite;
            SpriteState st = new SpriteState();
            st.pressedSprite = ssp;
            sbu.spriteState = st;

            sbu.onClick.AddListener(delegate{bloop(bu);});

        }

	}

	void Update ()
	{

	}
}
