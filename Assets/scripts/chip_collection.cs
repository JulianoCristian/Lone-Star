using UnityEngine;
using System.Collections;

public class chip_collection : MonoBehaviour {

    public int first_upgrade;
    public int second_upgrade;
    private int chip_count;
    GameObject gun_one;
    GameObject gun_two;
    GameObject gun_three;

    void Start () {
        chip_count = 0;
        first_upgrade = 3;
        second_upgrade = 6;
        gun_one = transform.GetChild(0).gameObject.transform.GetChild(0).gameObject;
        gun_two = transform.GetChild(0).gameObject.transform.GetChild(1).gameObject;
        gun_three = transform.GetChild(0).gameObject.transform.GetChild(2).gameObject;
    }
	
    void OnTriggerEnter(Collider col) {
        if(col.gameObject.tag == "chip"){
            Destroy(col.gameObject);
            chip_count = chip_count + 1;
        }
    }
	// Update is called once per frame
	void Update () {
        if(chip_count >= first_upgrade && chip_count < second_upgrade){
            gun_one.SetActive(false);
            gun_two.SetActive(true);
        }
        if(chip_count >= second_upgrade){
            gun_two.SetActive(false);
            gun_three.SetActive(true);
        }
	
	}
}
