using UnityEngine;
using System.Collections;

public class MenuControl : MonoBehaviour {

	public void ChangeScene(string sceneName)
	{
		Application.LoadLevel (sceneName);

	}
}
