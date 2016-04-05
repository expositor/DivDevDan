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

	void Start ()
	{
        rb = GetComponent<Rigidbody>();
        cam = Camera.main;

        speed = 0.1F;
	}

	void Update ()
	{
	    if (Input.GetAxis("Horizontal") != 0)
        {
            rb.MovePosition(rb.position + new Vector3(Mathf.Sign(Input.GetAxis("Horizontal")) * speed, 0, 0) );
        }

	    if (Input.GetAxis("Vertical") != 0)
        {
            rb.MovePosition(rb.position + new Vector3(0, Mathf.Sign(Input.GetAxis("Vertical")) * speed, 0) );
        }
	    // if (Input.GetAxis("Horizontal") != 0 & rb.velocity.x == 0)
        // {
        //     rb.AddForce(speed * Mathf.Sign(Input.GetAxis("Horizontal")),0,0);
        // }
        // else if (rb.velocity.x != 0)
        // {
        //     rb.AddForce(-speed * 0.5F * Mathf.Sign(rb.velocity.x), 0, 0);
        // }
        //
        // if (Input.GetAxis("Vertical") != 0 & rb.velocity.y < 10)
        // {
        //     rb.AddForce(0,speed * Mathf.Sign(Input.GetAxis("Vertical")),0);
        // }
        // else if (rb.velocity.y != 0)
        // {
        //     rb.AddForce(0, -speed * Mathf.Sign(rb.velocity.y), 0);
        // }

        if (Input.GetMouseButtonDown(0)) {
        	Vector3 mpos = Input.mousePosition;
        	Vector3 spos = cam.WorldToScreenPoint(transform.position);
        	float dir = Mathf.Atan2(mpos.y - spos.y, mpos.x - spos.x);
        	boolit f = shoot(transform.position, dir * 180 / Mathf.PI);
        	f.hp = 1;
        	f.dr = 10;
        	f.ddr = -9;
        }
	}

}
