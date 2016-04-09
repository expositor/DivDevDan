using UnityEngine;
using System.Collections;

public class Villain : MonoBehaviour {

    Pattern deploy_pattern()
    {
    	GameObject pre_pattern;
		pre_pattern = Resources.Load("Prefabs/Pattern") as GameObject;

		GameObject go_pattern = Instantiate(pre_pattern, transform.position, Quaternion.identity) as GameObject;
		Pattern patt = go_pattern.GetComponent<Pattern>();
		patt.father = gameObject;
		return patt;
    }

    float reload = 2f;
	float rtime = 0f;

    float pps(float a) {
    	return a * Time.deltaTime;
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (rtime <= 0) {
			Pattern f = deploy_pattern();
			f.hp = 1;
			f.shot_count = 7;
			f.shot_spread = 30f;
			f.angle = 250f;
			f.dangle = 40f;
			f.delay = 0.05f;
			f.mammo = 20;
			f.shot_r = 0.5f;

			f = deploy_pattern();
			f.hp = 2;
			f.shot_count = 20;
			f.shot_spread = 18f;
			f.dangle = -18f;
			f.delay = 0.5f;
			f.mammo = 20;
			f.shot_r = 0.5f;
			f.shot_dr = 5f;
			f.shot_ddr = -0.5f;
			f.shot_dp = -20f;
			rtime = reload;
		}
		rtime -= pps(1);

		Vector3 loc = transform.position;
		loc.x += Input.GetAxis("Horizontal") * Time.deltaTime * 5;
		transform.position = loc;
	}
}
