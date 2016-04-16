using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class newbutton : MonoBehaviour
{

    void Start()
    {
        GameObject moop = GameObject.FindWithTag("global");
        Debug.Log(moop);

        Button button = gameObject.GetComponent<Button>();
        Debug.Log(button);
        button.onClick.AddListener(delegate{Clicked();});
    }

    public string switchToScene;
    private void Clicked()
    {
        globalscript.Instance.SwitchScene(switchToScene);
    }
}
