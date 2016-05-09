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

    IEnumerator fade_sound(){
        float t = fade_time;
        while(t > 0){
            yield return null;
            t -= Time.deltaTime;
            death_sound.volume = t;
        }
        yield break;
    }

    void OnEnable(){
        life = life_total;
        dead = false;
    }

    public void life_subtract(){
        life = life - 1;
    }
	
	void Update () {
        if(life <= 0 && !dead){
            dead = true;
            death_sound.Play();
            //StartCoroutine(fade_sound());
        }
        if(dead && !death_sound.isPlaying){
            gameObject.SetActive(false);
        }
	}
}
