using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class collision_detection : MonoBehaviour {
    public Renderer rend;

    private Vector3 min_point; // bounds[0]
    private Vector3 max_point; // bounds[1]
    private float txmin, txmax, tymin, tymax, tzmin, tzmax;
    private GameObject bullet_pool;

   

    void Start () {
        rend = GetComponentInChildren<Renderer>();
        min_point = rend.bounds.min;
        max_point = rend.bounds.max;
        if (gameObject.tag == "player_collision")
            bullet_pool = GameObject.FindGameObjectWithTag("enemy_bullet_pool");
        else
            bullet_pool = GameObject.FindGameObjectWithTag("bullet_spawner");
    }

	void Update () {
        min_point = rend.bounds.min;
        max_point = rend.bounds.max;
        bullet_collision();
	}

    void bullet_collision() {
        List<GameObject> pool = bullet_pool.GetComponent<object_pooler>().get_pool();
        foreach (GameObject bullet in pool)
        {
            if(bullet.activeSelf){
                Vector3 origin = bullet.GetComponent<bullet_collision>().ray_origin;
                Vector3 dir = bullet.GetComponent<bullet_collision>().ray_direction;
                Ray r = new Ray(origin, dir);
                if (collision(r, 0.0f, .03f))
                {
                    //need to set ray origin and direction back to zero
                    //to keep from phantom bullets hitting enemies
                    bullet.GetComponent<bullet_collision>().ray_origin = Vector3.zero;
                    bullet.GetComponent<bullet_collision>().ray_direction = Vector3.zero;

                    if (gameObject.tag == "player_collision") {
                        print("I'm Dead");
                    }
                    else {
                        bullet.SetActive(false);
                        gameObject.GetComponent<enemy_lives>().life_subtract();
                    }
                }
            }
        }
    }

    public bool collision(Ray r, float t0, float t1) {
        if(r.direction.x >= 0) {
            txmin = (min_point.x - r.origin.x) / r.direction.x;
            txmax = (max_point.x - r.origin.x) / r.direction.x;
        }
        else {
            txmin = (max_point.x - r.origin.x) / r.direction.x;
            txmax = (min_point.x - r.origin.x) / r.direction.x;
        }
        if(r.direction.y >= 0) {
            tymin = (min_point.y - r.origin.y) / r.direction.y;
            tymax = (max_point.y - r.origin.y) / r.direction.y;
        }
        else {
            tymin = (max_point.y - r.origin.y) / r.direction.y;
            tymax = (min_point.y - r.origin.y) / r.direction.y;
        }
        if((txmin > tymax) || (tymin > txmax))
            return false;
        if (tymin > txmin)
            txmin = tymin;
        if (tymax < txmax)
            txmax = tymax;
        if(r.direction.z >= 0) {
            tzmin = (min_point.z - r.origin.z) / r.direction.z;
            tzmax = (max_point.z - r.origin.z) / r.direction.z;
        }
        else {
            tzmin = (max_point.z - r.origin.z) / r.direction.z;
            tzmax = (min_point.z - r.origin.z) / r.direction.z;
        }
        if ((txmin > tzmax) || (tzmin > txmax))
            return false;
        if (tzmin > txmin)
            txmin = tzmin;
        if (tzmax < txmax)
            txmax = tzmax;
        return ((txmin < t1) && (txmax > t0));
    }

    //draws bounding box for debugging purposes
    void OnDrawGizmosSelected() {
        Vector3 center = rend.bounds.center;
        Vector3 size = rend.bounds.extents * 2.0f;
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(center, size);
    }
}
