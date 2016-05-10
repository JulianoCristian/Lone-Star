using UnityEngine;
using System.Collections;

public class death : MonoBehaviour {

	private AudioSource death_sound;
	private bool dead;

	void Start () {
        AudioSource[] allMyAudioSources = GetComponents<AudioSource>();
    	death_sound = allMyAudioSources[3];
    	dead = false;
	}
	

    void OnTriggerEnter(Collider col) {
        if(col.gameObject.tag == "enemy" && !dead){
			death_sound.Play();
			dead = true;
			print("dead");
        }
    }

	void Update () {
		if(transform.position.y < 10 && !dead){
			print("dead");
			death_sound.Play();
			dead = true;
		}
	}
}
