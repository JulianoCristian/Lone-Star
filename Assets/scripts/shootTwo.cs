using UnityEngine;
using System.Collections;

public class shootTwo : MonoBehaviour {

	public GameObject bullet;
	public Transform[] spawn_positions;
	public float fire_speed;
	private float fire_interval_time;


	void Start () {
	}

	void Update () {
		if(Input.GetButton("Fire1")){
			if(fire_interval_time <= 0){
				if(bullet){
					for(int i = 0; i < spawn_positions.Length; i++){
						Instantiate(bullet, spawn_positions[i].position, spawn_positions[i].rotation);
						bullet.GetComponent<movement>().direction = spawn_positions[i].forward;
					}
				}
				fire_interval_time = 1;
			}
		}
		fire_interval_time = fire_interval_time - (Time.deltaTime * fire_speed);
	}
}
