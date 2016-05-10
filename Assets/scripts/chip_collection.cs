using UnityEngine;
using System.Collections;

public class chip_collection : MonoBehaviour {

    public int first_upgrade;
    public int second_upgrade;
    private bool first = false;
    private bool second = false;
    private int chip_count;
    private AudioSource chip_sound;
    private AudioSource upgrade_sound;
    GameObject gun_one;
    GameObject gun_two;
    GameObject gun_three;

    void Start () {
        chip_count = 0;
        gun_one = transform.GetChild(0).gameObject.transform.GetChild(0).gameObject;
        gun_two = transform.GetChild(0).gameObject.transform.GetChild(1).gameObject;
        gun_three = transform.GetChild(0).gameObject.transform.GetChild(2).gameObject;

        AudioSource[] allMyAudioSources = GetComponents<AudioSource>();
        chip_sound = allMyAudioSources[1];
        upgrade_sound = allMyAudioSources[2];
    }
	
    void OnTriggerEnter(Collider col) {
        if(col.gameObject.tag == "chip" && chip_count < second_upgrade){
            chip_count = chip_count + 1;
            if(chip_count != first_upgrade && chip_count != second_upgrade)
                chip_sound.Play();  
        }
    }
    // Update is called once per frame
    void Update () {
        if(chip_count >= first_upgrade && chip_count < second_upgrade && !first){
            gun_one.SetActive(false);
            gun_two.SetActive(true);
            first = true;
            upgrade_sound.Play();
        }
        if(chip_count >= second_upgrade && !second){
            gun_two.SetActive(false);
            gun_three.SetActive(true);
            second = true;
            upgrade_sound.Play();
        }
	
	}
}
