using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Scenebutton : MonoBehaviour
{

    void Start()
    {
        Button button = gameObject.GetComponent<Button>();
        button.onClick.AddListener(delegate{Clicked();});
    }

    public string switchToScene;
    private void Clicked()
    {
        Globalscript.Instance.SwitchScene(switchToScene);
    }
}
