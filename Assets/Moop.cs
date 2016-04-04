using UnityEngine;
using System.Collections;

public class Moop : MonoBehaviour
{
    string myName;
    float speed = 10;

	// Use this for initialization
	void Start ()
	{
	    Debug.Log("Moop: " + myName);
	}
	// Update is called once per frame
	void Update ()
	{
        float distanceh = speed * Time.deltaTime * Input.GetAxis("Horizontal");
        float distancev = speed * Time.deltaTime * Input.GetAxis("Vertical");
	    if (Input.GetKey("space"))
        {
            transform.Rotate(distanceh * Input.GetAxis("Horizontal"), 0, 0);
            transform.Rotate(0, distancev * Input.GetAxis("Vertical"), 0);
        }
        else
        {
            transform.Translate(distanceh, 0, 0);
            transform.Translate(0, distancev, 0);
        }
	}
}
