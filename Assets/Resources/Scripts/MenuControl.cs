using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;


public class MenuControl : MonoBehaviour {

	public void ChangeScene(string sceneName)
	{
	    SceneManager.LoadScene(sceneName);
	}
}
