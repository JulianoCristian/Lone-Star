using UnityEngine;
using System.Collections;

public class surround_audio : MonoBehaviour {

	private AudioSource static_sound;

	void Start () {
        AudioSource[] allMyAudioSources = GetComponents<AudioSource>();
    	static_sound = allMyAudioSources[1];
	}
	
	// Update is called once per frame
	void Update () {
		if(!static_sound.isPlaying){
			static_sound.Play();
		}
	
	}
}
