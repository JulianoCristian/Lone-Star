using UnityEngine;
using System.Collections;

public class bullet_collision : MonoBehaviour {

    private GameObject[] enemy_list;
    public Vector3 ray_origin;
    public Vector3 ray_direction;

	void Start () {
	
	}
	
	void Update () {

        //gets every enemy in the scene every frame
        //enemy_list = GameObject.FindGameObjectsWithTag("Enemy");

        //starting and end point of ray
        ray_origin = transform.position;
        ray_direction = transform.TransformDirection(Vector3.forward) * .10f;

        //checkForCollision(start_ray, end_ray);
        //if(Physics.Raycast(transform.position, fwd, 1.0f)) {
        //    Debug.Log("Collision!");
        //}
	}

    void checkForCollision(Vector3 start_ray, Vector3 end_ray) {
        foreach(GameObject e in enemy_list) {
            Renderer rend = e.GetComponent<Renderer>();           
        }
    }
}
