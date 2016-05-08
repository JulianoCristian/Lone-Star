using UnityEngine;
using System.Collections;


public class destroy : MonoBehaviour {

	public float destroy_time = 5f;
	
	void OnEnable(){
		Invoke("Destroy", destroy_time);
	}

	void Destroy(){
		gameObject.SetActive(false);
	}

	void OnDisable(){
		CancelInvoke();
	}


}
