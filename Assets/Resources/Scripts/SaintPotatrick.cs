using UnityEngine;
using System.Collections;

public class SaintPotatrick : MonoBehaviour
{
    public int scrollDistanceX;
    public int scrollDistanceY;
    public float scrollSpeed;

	void Update ()
	{
		Vector3 loc = transform.position;

		loc.x += Input.GetAxis("Horizontal") * Time.deltaTime * 100;
		loc.y += Input.GetAxis("Vertical") * Time.deltaTime * 100;

        if
        (
            transform.position.x - Camera.main.transform.position.x > scrollDistanceX &
            Camera.main.transform.position.x < Globalscript.Instance.pixelsX/2 - 256
        )
        { Camera.main.transform.position += new Vector3(scrollSpeed,0); }
        else if
        (
            Camera.main.transform.position.x - transform.position.x > scrollDistanceX &
            Camera.main.transform.position.x > -Globalscript.Instance.pixelsX/2 + 256
        )
        { Camera.main.transform.position += new Vector3(-scrollSpeed,0); }
        else if
        (
            transform.position.y - Camera.main.transform.position.y > scrollDistanceY &
            Camera.main.transform.position.y < Globalscript.Instance.pixelsY/2 - 144
        )
        { Camera.main.transform.position += new Vector3(0, scrollSpeed); }
        else if
        (
            Camera.main.transform.position.y - transform.position.y > scrollDistanceY &
            Camera.main.transform.position.y > -Globalscript.Instance.pixelsY/2 + 144
        )
        { Camera.main.transform.position += new Vector3(0, -scrollSpeed); }

		transform.position = loc;

	}

}
