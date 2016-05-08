using UnityEngine;
using System.Collections;

public class movement : MonoBehaviour {

	public float speed = 40;
	public Vector3 direction;

	void Start () {
	}
	
	void Update () {
		transform.position += direction * speed * Time.deltaTime;
	}
}
