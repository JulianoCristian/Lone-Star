using UnityEngine;
using System.Collections;

public class stationary_enemy_spawner : MonoBehaviour {

    public GameObject child;
    public float respawn_time;

    private float timer;

    void Start() {
        timer = respawn_time;
    }
	
	void Update () {

        if (!child.activeSelf) {
            timer = timer - Time.deltaTime;
            if (timer < 0) {
                timer = respawn_time;
                child.SetActive(true);
            }
        }
    }
}
