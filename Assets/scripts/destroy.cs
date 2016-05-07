using UnityEngine;
using System.Collections;


public class destroy : MonoBehaviour {

	public float distroy_time;
	// Use this for initialization
	void Start () {
		Destroy(gameObject, distroy_time);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
