using UnityEngine;
using System.Collections;

public class boolit : MonoBehaviour {
	public float p = 180f;
	public float r = 1f;
	public float dp = 0f;
	public float dr = 0f;
    public float ddp = 0f;
	public float ddr = 0f;
	public float hp = 10f;

	float cx;
	float cy;

	float pps(float a) {
		return a * Time.deltaTime;
	}

	float cos(float a) {
		return Mathf.Cos(a);
	}

	float sin(float a) {
		return Mathf.Sin(a);
	}

	float dtr(float a) {
		return a * Mathf.PI / 180f;
	}

	float rtd(float a) {
		return a * 180f / Mathf.PI;
	}

	// Use this for initialization
	void Start () {
		cx = transform.position.x;
		cy = transform.position.y;
	}

	// Update is called once per frame
	void Update () {
		dp += pps(ddp);
		dr += pps(ddr);
		p += pps(dp);
		r += pps(dr);

		Vector3 loc = transform.position;
		loc.x = cx + r * cos(dtr(p));
		loc.y = cy + r * sin(dtr(p));
		transform.position = loc;

		float u = transform.rotation.eulerAngles.z;

		float p2 = dtr(p + pps(dp));
		float r2 = r + pps(dr);
		Vector2 velocity = new Vector2(r2*cos(p2) - r*cos(dtr(p)), r2*sin(p2) - r*sin(dtr(p)));
		float v = rtd(Mathf.Atan2(velocity.y, velocity.x)) - 90;

		Vector3 rot = new Vector3(0.0f, 0.0f, v - u);
		transform.Rotate(rot);

		hp -= pps(1);
		if (hp <= 0f) {
			Destroy(gameObject);
		}
	}
}
