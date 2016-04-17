using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Globalscript : MonoBehaviour
{
    static Globalscript instance;

    public static Globalscript Instance
    {
        get { return instance; }
    }

    public void SwitchScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    void Start()
    {
        DontDestroyOnLoad(gameObject);
        instance = this;
    }

	void OnGUI()
    {
        Event e = Event.current;
        if (e.Equals(Event.KeyboardEvent("Escape")))
        {

            if (SceneManager.GetActiveScene().name.Equals("Titlescreen")) { Application.Quit(); }
            else { SceneManager.LoadScene("Titlescreen"); }

        }

    }

}
