using UnityEngine;
using System.Collections;

public class stationary_enemy_spawner : MonoBehaviour {

    public GameObject child;
    public float respawn_time;
    public float start_time = 10;

    private float timer;

    void Start()
    {
        timer = respawn_time;
        child.SetActive(false);
    }

    void Update()
    {
        start_time = start_time - Time.deltaTime;
        if(start_time < 0){
            if (!child.activeSelf) {
                timer = timer - Time.deltaTime;
                if (timer < 0) { 
                    timer = respawn_time;
                    child.SetActive(true);
                }
            }
        }
    }
}
