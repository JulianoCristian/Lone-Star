using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class pauseMenu : MonoBehaviour {


		public Canvas pauseMenu1;
		public Button startText;
		public Button exitText;
        public death player;

        public bool pauseState;

		private AudioSource new_game_sound;
   		private AudioSource quit_sound;
   		private AudioSource menu_sound;

   		public bool get_pause_state(){
   			return pauseState;
   		}

		void Start () {
			pauseMenu1 = pauseMenu1.GetComponent<Canvas> ();
			startText = startText.GetComponent<Button> ();
			exitText = exitText.GetComponent<Button> ();

			pauseMenu1.enabled = false;

			Cursor.visible = false;


			AudioSource[] allMyAudioSources = GetComponents<AudioSource>();
    		new_game_sound = allMyAudioSources[0];
    		quit_sound = allMyAudioSources[1];
    		menu_sound = allMyAudioSources[2];
		}

		// Update is called once per frame
		void Update () {
			if(Input.GetKeyDown("escape") && !player.is_dead()){
				pauseState = !pauseState;
				pauseMenu1.enabled = true;
				menu_sound.Play();
			}

			if(pauseState){
				Time.timeScale = 0;
				Cursor.visible = true;
			}

			if(pauseState == false && !player.is_dead()){
				Time.timeScale = 1;
				Cursor.visible = false;
				pauseMenu1.enabled = false;
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
			StartCoroutine(play_new_game_sound());
		}

		public void ExitPress(){
			quit_sound.Play();
			Debug.Log ("Game Exited");
			StartCoroutine(play_quit_sound());
		}


	}


