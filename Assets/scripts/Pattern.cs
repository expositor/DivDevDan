using UnityEngine;
using System.Collections;

public class pattern : MonoBehaviour {

	public float hp = 5f;

	public float reload = 0.5f;
	float rtime = 0f;

	public float delay = 0.1f;
	float dtime = 0f;

	public int mammo = 6;
	int ammo;

	public float angle = 0f;
	public float dangle = 60f;
	
	public int shot_count = 5;
	public float shot_spread = 8f;
	public float shot_r = 0f;
	public float shot_dr = 10f;
	public float shot_ddr = -2f;
	public float shot_dp = 0f;
	public float shot_ddp = 0f;
	public float shot_hp = 5f;

	public GameObject father;
	bool has_father;

    Camera cam;

    boolit shoot(Vector3 location, float direction)
    {
    	GameObject Shot;
    	Shot = Resources.Load("Boolit") as GameObject;

    	GameObject go_shot = Instantiate(Shot, location, Quaternion.identity) as GameObject;
    	boolit shot = go_shot.GetComponent<boolit>();
    	shot.p = direction;
    	return shot;
    }

    float pps(float a) {
    	return a * Time.deltaTime;
    }

	// Use this for initialization
	void Start () {
		if (father != null) {
			has_father = true;
		}
		ammo = mammo;
	}
	
	// Update is called once per frame
	void Update () {
		angle += pps(dangle);
	
		hp -= pps(1);
		if (hp <= 0) {
			Destroy(gameObject);
		}
		if (father == null
		&& has_father == true) {
			Destroy(gameObject);
		}

		if (has_father == true) {
			Vector3 loc = transform.position;
			loc.x = father.transform.position.x;
			loc.y = father.transform.position.y;
			transform.position = loc;
		}
		
		dtime -= pps(1);
		if (ammo <= 0) {
			rtime -= pps(1);
		}

		//Reload
		if (rtime <= 0) {
			rtime = reload;
			ammo = mammo;
		}

		//Fire
		if (dtime <= 0) {
			ammo --;
			dtime = delay;
			float oangle = shot_spread * (shot_count - 1) / 2;
			for (float i = 0f; i < shot_count; i++) {
				boolit f = shoot(transform.position, angle - oangle + shot_spread*i);
				f.r = shot_r;
				f.dr = shot_dr;
				f.ddr = shot_ddr;
				f.dp = shot_dp;
				f.ddp = shot_ddp;
				f.hp = shot_hp;
			}
		}
	}
}
