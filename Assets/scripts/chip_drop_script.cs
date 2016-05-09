using UnityEngine;
using System.Collections;

public class chip_drop_script : MonoBehaviour {

    private GameObject chip_pool;

    private bool spawnable = false;
    private bool loaded = false;

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
        if(!GetComponent<MeshRenderer>().enabled && spawnable){
            GameObject chip = chip_pool.GetComponent<object_pooler>().get_pooled_object();
            if(chip == null) return;

            chip.transform.position = transform.position;
            chip.transform.rotation = transform.rotation;
            chip.SetActive(true);
            spawnable = false;
        }
    }
}
