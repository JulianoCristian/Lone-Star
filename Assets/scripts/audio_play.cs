using UnityEngine;
using System.Collections;

public class audio_play : MonoBehaviour {


    private AudioSource fire_sound;
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
        if(Input.GetButton("Fire1")){
            StopCoroutine(fade_sound());
            fire_sound.volume = fade_time;
            if(!fire_sound.isPlaying){
                fire_sound.Play();
            }
        }
        if(Input.GetButtonUp("Fire1")){
            StartCoroutine(fade_sound());
            fire_sound.volume = fade_time;
        }
	}
}
