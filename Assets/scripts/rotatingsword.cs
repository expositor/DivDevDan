using UnityEngine;
using System.Collections;

public class rotatingsword : MonoBehaviour
{

	void Start ()
	{
	}
	void Update ()
	{
        transform.Rotate(0,0,0.03F);
	}
}
