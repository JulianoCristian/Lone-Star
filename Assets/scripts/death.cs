using UnityEngine;
using System.Collections;

public class death : MonoBehaviour {

	private AudioSource death_sound;
	private bool dead;

    public Canvas game_over_menu;

    public bool get_death_state(){
        return dead;
    }

	void Start () {
        AudioSource[] allMyAudioSources = GetComponents<AudioSource>();
    	death_sound = allMyAudioSources[3];
    	dead = false;
	}

    void OnTriggerEnter(Collider col) {
		if(col.gameObject.tag == "enemy" && !dead){
            game_over_menu.enabled = true;
            death_sound.Play();
			dead = true;
			transform.rotation = new Quaternion(0, 0, 90, 1); 
        }
    }

	void Update () {
		if(transform.position.y < 10 && !dead){
            game_over_menu.enabled = true;
			death_sound.Play();
			dead = true;
		}
	}

    public bool is_dead() {
        return dead;
    }

    public void set_death(bool val) {
        dead = val;
    }

    public AudioSource get_death_sound(){
        return death_sound;
    }
}
