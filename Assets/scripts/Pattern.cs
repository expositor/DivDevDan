using UnityEngine;
using System.Collections;

public class Pattern : MonoBehaviour {

	float hp = 0f;

	float reload = 0.5f;
	float rtime = 0f;

	float delay = 0.1f;
	float dtime = 0f;

	int mammo = 6;
	int ammo = 6;

	float angle = 0f;
	float dangle = 0f;

	int shot_count = 5;
	float shot_spread = 5f;
	float shot_r = 0f;
	float shot_dr = 10f;
	float shot_ddr = -2f;
	float shot_dp = 0f;
	float shot_ddp = 0f;
	float shot_hp = 5f;

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
		
	}
	
	// Update is called once per frame
	void Update () {
		hp -= pps(1);
		if (hp <= 0) {
			Destroy(gameObject);
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
