using UnityEngine;
using System.Collections;

public class Rotater : MonoBehaviour
{

	void Start ()
	{
	}
	void Update ()
	{
        transform.Rotate(0,0,0.03F);
	}
}
