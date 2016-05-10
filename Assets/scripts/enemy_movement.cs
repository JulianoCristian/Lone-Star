using UnityEngine;
using System.Collections;

public class enemy_movement : MonoBehaviour {

    public float speed = 15f;

    private Rigidbody body;
    private Transform target;
    


	void Start () {
        body = GetComponent<Rigidbody>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
	
        Vector3 displacement_from_target = target.position - transform.position;
        Vector3 direction_to_target = displacement_from_target.normalized;
        Vector3 velocity = direction_to_target * speed;
        
        body.AddForce(velocity);

        Vector3 target_dir = target.position - transform.position;
        float step = speed * Time.deltaTime;
        Vector3 new_dir = Vector3.RotateTowards(transform.forward, target_dir, step, 0.0f);
        transform.rotation = Quaternion.LookRotation(new_dir);
        //transform.Translate(velocity * Time.deltaTime);
    }
}
