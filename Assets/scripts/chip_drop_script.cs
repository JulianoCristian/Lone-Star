using UnityEngine;
using System.Collections;

public class chip_drop_script : MonoBehaviour {

    private GameObject chip_pool;

    private bool spawnable = false;
    private bool loaded = false;
    private Transform mesh_location;

	void Start () {
        loaded = true;
        spawnable = true;
        chip_pool = GameObject.FindGameObjectWithTag("chip_pool");
	}

    void OnEnable(){
        if(loaded)
            spawnable = true;
    }
    
    void Update(){

        if (gameObject.name.Contains("enemyC_new"))
            mesh_location = transform.Find("PA_DropPod").Find("PA_DropPod 1");
        else if (gameObject.name.Contains("Rotate_Object"))
            mesh_location = transform.parent.parent.parent.Find("GunPlat_1");

        if (!mesh_location.GetComponent<MeshRenderer>().enabled && spawnable){
            GameObject chip = chip_pool.GetComponent<object_pooler>().get_pooled_object();
            if(chip == null) return;

            chip.transform.position = transform.position;
            chip.transform.rotation = transform.rotation;
            chip.SetActive(true);
            spawnable = false;
        }
    }
}
