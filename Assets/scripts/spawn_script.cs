using UnityEngine;
using System.Collections;

public class spawn_script : MonoBehaviour {

    public int spawn_amount = 10;
    public GameObject pool;
    public float spawn_interval = 10;
    public float start_time = 10;
    
    private float timer;

	// Use this for initialization
	void Start (){
        timer = 0;
	
	}
	
	// Update is called once per frame
	void Update () {
        timer = timer - Time.deltaTime;
        start_time = start_time - Time.deltaTime;
        if(start_time < 0){
            if(timer <= 1){
                timer = spawn_interval;
                for(int i = 0; i < spawn_amount; i++){
                    GameObject enemy = pool.GetComponent<object_pooler>().get_pooled_object();
                    if(enemy == null) return;

                    enemy.transform.position = transform.position;
                    enemy.transform.rotation = transform.rotation;
                    enemy.SetActive(true);
                }
            }
        }
	
	}
}
