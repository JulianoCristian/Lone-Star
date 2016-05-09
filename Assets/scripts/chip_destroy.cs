using UnityEngine;
using System.Collections;

public class chip_destroy : MonoBehaviour {

    void OnTriggerEnter(Collider col){
        if(col.gameObject.tag == "Player"){
            gameObject.SetActive(false);
        }
    }
}
