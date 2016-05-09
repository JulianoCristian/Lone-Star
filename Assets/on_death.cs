using UnityEngine;
using System.Collections;

public class on_death : MonoBehaviour {


    private AudioSource death_sound;
    public float fade_time;

	void Start () {
        death_sound = GetComponent<AudioSource>();
        fade_time = 0.3f;
	}

    IEnumerator _fade_sound(){
        float t = fade_time;
        while(t > 0){
            yield return null;
            t -= Time.deltaTime;
            death_sound.volume = t;
        }
        yield break;
    }

    void OnDisable(){
        StartCoroutine(_fade_sound());
    }
}
