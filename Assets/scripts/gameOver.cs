using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class gameOver : MonoBehaviour {


	public Canvas gameOverMenu1;
	public Button startText;
	public Button exitText;
    public Text score;
    public timer time;

    public bool death_state;


    private AudioSource new_game_sound;
    private AudioSource quit_sound;

	void Start () {
        gameOverMenu1 = gameOverMenu1.GetComponent<Canvas> ();
		startText = startText.GetComponent<Button> ();
		exitText = exitText.GetComponent<Button> ();

        gameOverMenu1.enabled = false;
        death_state = false;


        AudioSource[] allMyAudioSources = GetComponents<AudioSource>();
    	new_game_sound = allMyAudioSources[0];
    	quit_sound = allMyAudioSources[1];

	}
	void Update (){
        if (gameOverMenu1.isActiveAndEnabled) {
            Time.timeScale = 0;
            death_state = true;
            score.text = "Score: " + time.get_total_time().ToString("#.00"); 
        }
        else {
            Time.timeScale = 1;
            death_state = false;
        }
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
        death_state = false;
        StartCoroutine(play_new_game_sound());
	}

	public void ExitPress(){
		Debug.Log ("Game Exited");
		StartCoroutine(play_quit_sound());
	}
}
