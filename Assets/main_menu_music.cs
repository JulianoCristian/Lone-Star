using UnityEngine;
using System.Collections;

public class main_menu_music : MonoBehaviour {

	private AudioSource menu_music;
	void Start () {
		menu_music = GetComponent<AudioSource>();
	
	}
	
	// Update is called once per frame
	void Update () {
		if(!menu_music.isPlaying)
			menu_music.Play();
	}
}
