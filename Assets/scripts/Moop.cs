using UnityEngine;
using System.Collections;

public class Moop : MonoBehaviour
{
    public Rigidbody rb;
    public float speed;

	void Start ()
	{
        rb = GetComponent<Rigidbody>();

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

	}

}
