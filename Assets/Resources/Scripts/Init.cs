using UnityEngine;
using System.Collections;

public class Init : MonoBehaviour
{

	void Awake()
	{
	    if (FindObjectOfType<Globalscript>() == null)
        {
	        GameObject obj = new GameObject("%Globalscript");
	        obj.tag = "%Global";
	        obj.AddComponent<Globalscript>();
        }
	}

}
