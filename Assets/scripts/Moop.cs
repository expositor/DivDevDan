using UnityEngine;
using System.Collections;

public class Moop : MonoBehaviour
{
    public Rigidbody rb;
    public float speed;
    Camera cam;

    public static boolit shoot(Vector3 location, float direction)
    {
    	GameObject Shot;
    	Shot = Resources.Load("Boolit") as GameObject;

    	GameObject go_shot = Instantiate(Shot, location, Quaternion.identity) as GameObject;
    	boolit shot = go_shot.GetComponent<boolit>();
    	shot.p = direction;
    	return shot;
    }
    private int jump;
    private bool button;

	void Start ()
	{
        rb = GetComponent<Rigidbody>();
        cam = Camera.main;

        speed = 0.1F;
        jump = 2;
	}

	void Update ()
	{
	    if (Input.GetAxis("Horizontal") != 0)
        {
            rb.MovePosition(rb.position + new Vector3(Input.GetAxis("Horizontal") * speed, 0, 0) );
        }

	    if (Input.GetAxis("Vertical") != 0)
        {
            rb.MovePosition(rb.position + new Vector3(0, 0, Input.GetAxis("Vertical") * speed) );
        }

        if (Input.GetMouseButtonDown(0)) {
        	Vector3 mpos = Input.mousePosition;
        	Vector3 spos = cam.WorldToScreenPoint(transform.position);
        	float dir = Mathf.Atan2(mpos.y - spos.y, mpos.x - spos.x);
        	boolit f = shoot(transform.position, dir * 180 / Mathf.PI);
        	f.hp = 1;
        	f.dr = 10;
        	f.ddr = -9;
		}

        if (Input.GetMouseButtonDown(1)) {
        	Vector3 mpos = Input.mousePosition;
        	Vector3 spos = cam.WorldToScreenPoint(transform.position);
        	float dir = Mathf.Atan2(mpos.y - spos.y, mpos.x - spos.x);
			for (float i = 0f; i < 6; i++)
			{
	        	boolit f = shoot(transform.position, i * 60);
	        	f.hp = 2;
	        	f.dr = 8;
	        	f.ddr = -2;
	        	f.dp = 30;

	        	f = shoot(transform.position, i * 60);
	        	f.hp = 2;
	        	f.dr = 8;
	        	f.ddr = -2;
	        	f.dp = -30;
        	}
        }

	    if (Input.GetButtonDown("Jump") & button == false)
        {
            button = true;
            if (jump > 0) { rb.AddForce(0, 600, 0); jump--; }
        }
        else if (Input.GetButtonUp("Jump") & button == true)
        {
            button = false;
        }
	}

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag.Equals("Jumpable")) { jump = 2; }
    }

}
