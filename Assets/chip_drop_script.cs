using UnityEngine;
using System.Collections;

public class chip_drop_script : MonoBehaviour {

    public GameObject pool;

    private float timer = 1;
	void Start () {
	
	}


    void OnDisable(){
        if(timer < 0)
            Instantiate(pool, transform.position, transform.rotation);
    }

	
	// Update is called once per frame
	void Update () {
        timer = timer - Time.deltaTime;
	
	}
}
