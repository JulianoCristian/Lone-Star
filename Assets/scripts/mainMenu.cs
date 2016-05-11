using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class mainMenu : MonoBehaviour {

	public Canvas mainMenu1;
	public Button startText;
	public Button exitText;


	private bool pauseState;


	private AudioSource new_game_sound;
    private AudioSource quit_sound;

	void Start () {
	
		mainMenu1 = mainMenu1.GetComponent<Canvas> ();
		startText = startText.GetComponent<Button> ();
		exitText = exitText.GetComponent<Button> ();

		Cursor.visible = true;

		AudioSource[] allMyAudioSources = GetComponents<AudioSource>();
    	new_game_sound = allMyAudioSources[0];
    	quit_sound = allMyAudioSources[1];

	}



	IEnumerator play_new_game_sound(){
		new_game_sound.Play();
	    while(new_game_sound.isPlaying){
	      	yield return null;
	    }
		Application.LoadLevel(1);
	    yield break;
    }

    IEnumerator play_quit_sound(){
		quit_sound.Play();
	    while(new_game_sound.isPlaying){
	        yield return null;
	    }
		Application.Quit();
	    yield break;
    }


	public void StartPress(){
		Cursor.visible = false;
		mainMenu1.enabled = false;
		StartCoroutine(play_new_game_sound());

	}

	public void ExitPress(){
		Debug.Log ("Game Exited");
		StartCoroutine(play_quit_sound());
	}
		

}
