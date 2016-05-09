using UnityEngine;
using System.Collections;

public class enemy_lives : MonoBehaviour {

    public int life_total;
    private int life;
    private bool dead = false;

    private AudioSource death_sound;
    public float fade_time;

	void Start () {
        death_sound = GetComponent<AudioSource>();
	    life = life_total;
        fade_time = 0.3f;

	}

    void OnEnable(){
        life = life_total;
        dead = false;
        GetComponent<MeshRenderer>().enabled = true;
        GetComponent<collision_detection>().enabled = true;
    }

    public void life_subtract(){
        life = life - 1;
    }
	
	void Update () {
        if(life <= 0 && !dead){
            dead = true;
            death_sound.Play();
            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<collision_detection>().enabled = false;
        }
        if(dead && !death_sound.isPlaying){
            gameObject.SetActive(false);
        }
	}
}
