using UnityEngine;
using System.Collections;

public class Moop : MonoBehaviour
{
    public Rigidbody rb;
    public float speed;
    private int jump;
    private bool button;

	void Start ()
	{
        rb = GetComponent<Rigidbody>();

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
