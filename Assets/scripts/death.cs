using UnityEngine;
using System.Collections;

public class death : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	

    void OnTriggerEnter(Collider col) {
        if(col.gameObject.tag == "enemy"){
			print("i am dead");
        }
    }

	// Update is called once per frame
	void Update () {
		if(transform.position.y < 10){
			print("i am dead");
		}
	}
}
