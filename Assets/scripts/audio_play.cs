using UnityEngine;
using System.Collections;

public class audio_play : MonoBehaviour {


    private AudioSource fire_sound;
    private bool pause_state;
    private bool death_state;
    public float fade_time;

	void Start () {
        fire_sound = GetComponent<AudioSource>();
        fade_time = 0.3f;
    }
	
    IEnumerator fade_sound(){
        float t = fade_time;
        while(t > 0 && !Input.GetButton("Fire1")){
            yield return null;
            t -= Time.deltaTime;
            fire_sound.volume = t;
        }
        yield break;
    }

	void Update () {

        pause_state = GameObject.FindGameObjectWithTag("PauseMenu").GetComponent<pauseMenu>().pauseState;
        death_state = GameObject.FindGameObjectWithTag("GameOverMenu").GetComponent<gameOver>().death_state;


        if(Input.GetButton("Fire1") && (pause_state || death_state)) {
            if (fire_sound.isPlaying)
                fire_sound.Stop();
        }

        if (!Input.GetButton("Fire1") && (pause_state || death_state))
        {
            if (fire_sound.isPlaying)
                fire_sound.Stop();
        }

        if (Input.GetButton("Fire1") && (!pause_state && !death_state)){
            StopCoroutine(fade_sound());
            fire_sound.volume = fade_time;
            if(!fire_sound.isPlaying){
                fire_sound.Play();
            }
        }
        if(Input.GetButtonUp("Fire1") && (!pause_state && !death_state))
        {
            StartCoroutine(fade_sound());
            fire_sound.volume = fade_time;
        }
	}
}
