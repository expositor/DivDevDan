using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class globalscript : MonoBehaviour
{
    static globalscript instance;

    float sims = 1;

    public float pps(float a) {
    	return a * sims * Time.deltaTime;
    }

    public float set_sims(float a) {
    	sims = a;
    }
    
    public static globalscript Instance
    {
        get
        {
            if (instance == null) { instance = FindObjectOfType<globalscript>(); }
            if (instance == null)
            {
                GameObject obj = new GameObject("Globalscript");
                obj.hideFlags = HideFlags.HideAndDontSave;
                instance = obj.AddComponent<globalscript>();
            }

            return instance;
        }
    }

    public void SwitchScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    private void Awake()
    {
        if (instance != null && instance != this)
        {

            Destroy(this.gameObject);
            return;

        }

        instance = this;
        DontDestroyOnLoad( this.gameObject );
    }

	void OnGUI()
    {
        Event e = Event.current;
        if (e.Equals(Event.KeyboardEvent("escape")))
        {

            if (SceneManager.GetActiveScene().name.Equals("titlescreenNEW2")) { Application.Quit(); }
            else { SceneManager.LoadScene("titlescreenNEW2"); }

        }

    }

}
