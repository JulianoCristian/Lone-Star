using UnityEngine;
using System.Collections;

public class static_audio : MonoBehaviour {

	private AudioSource static_sound;
    public float fade_time;

	void Start () {
        static_sound = GetComponent<AudioSource>();
        fade_time = 0.3f;
	}
	
	// Update is called once per frame
	void Update () {
		if(!static_sound.isPlaying){
			static_sound.Play();
		}
	
	}
}
