using UnityEngine;
using System.Collections;

public class SaintPotatrick : MonoBehaviour
{
    public int scrollDistanceX;
    public int scrollDistanceY;

	void Start ()
	{
	}

	void Update ()
	{
		Vector3 loc = transform.position;

		loc.x += Input.GetAxis("Horizontal") * Time.deltaTime * 100;
		loc.y += Input.GetAxis("Vertical") * Time.deltaTime * 100;

		if ( transform.position.x - Camera.main.transform.position.x  > scrollDistanceX)
        {
            Camera.main.transform.position += new Vector3(1,0);
        }
        else if ( Camera.main.transform.position.x - transform.position.x > scrollDistanceX)
        {
            Camera.main.transform.position += new Vector3(-1,0);
        }
        else if ( transform.position.y - Camera.main.transform.position.y > scrollDistanceY)
        {
            Camera.main.transform.position += new Vector3(0,1);
        }
        else if ( Camera.main.transform.position.y - transform.position.y > scrollDistanceY)
        {
            Camera.main.transform.position += new Vector3(0,-1);
        }


		// if ( Mathf.Abs( transform.position.y - camPos.y ) > scrollDistance)
        // {
        //     camPos = loc - new Vector3(0, scrollDistance);
        //     Camera.main.transform.position = loc - new Vector3(0, scrollDistance);
        // }

		transform.position = loc;
	}

}
