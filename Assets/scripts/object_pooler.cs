using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class object_pooler : MonoBehaviour {

	public static object_pooler current;
    public GameObject pool_obj;
    public int pool_size = 100;
    public bool can_grow = true;

    List<GameObject> pool;

    void Awake(){
        current = this;
    }

	void Start () {
        pool = new List<GameObject>();

        for(int i = 0; i < pool_size; i++){
            GameObject obj = (GameObject)Instantiate(pool_obj);
            obj.SetActive(false);
            pool.Add(obj);
        }
	}

    public GameObject get_pooled_object(){
        for(int i = 0; i < pool.Count; i++){
            if(!pool[i].activeInHierarchy){
                return pool[i];
            }
        }
        if(can_grow){
            GameObject obj = (GameObject)Instantiate(pool_obj);
            pool.Add(obj);
            return obj;
        }
        return null;
    }

    public List<GameObject> get_pool()
    {
        return pool;
    }
}
