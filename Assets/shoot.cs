using UnityEngine;
using System.Collections;

public class shoot : MonoBehaviour {


	public GameObject bullet;
	public Transform spawn_position;
	public float fire_speed;
	private float fire_interval_time;


	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
		if(Input.GetButton("Fire1")){
			if(fire_interval_time <= 0){
				if(bullet){
					Instantiate(bullet, spawn_position.position, spawn_position.rotation);
					bullet.GetComponent<movement>().direction = spawn_position.forward;
				}
				fire_interval_time = 1;
			}
		}
		fire_interval_time = fire_interval_time - (Time.deltaTime * fire_speed);
	}
}
