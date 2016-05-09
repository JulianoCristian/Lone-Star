using UnityEngine;
using System.Collections;

public class bullet_collision : MonoBehaviour {

    public Vector3 ray_origin;
    public Vector3 ray_direction;

	void Start () {
    }
	
	void Update () {
        //starting and end point of ray
        ray_origin = transform.position;
        ray_direction = transform.TransformDirection(Vector3.forward) * .10f;
	}
}
