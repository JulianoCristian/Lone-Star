using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class pauseMenu : MonoBehaviour {


		public Canvas pauseMenu1;
		public Button startText;
		public Button exitText;
        public death player;

        public bool pauseState;

		// Use this for initialization
		void Start () {


			pauseMenu1 = pauseMenu1.GetComponent<Canvas> ();
			startText = startText.GetComponent<Button> ();
			exitText = exitText.GetComponent<Button> ();


			pauseMenu1.enabled = false;

		Cursor.visible = false;




		}

		// Update is called once per frame
		void Update () {
			if(Input.GetKeyDown("escape") && !player.is_dead()){
				pauseState = !pauseState;
				pauseMenu1.enabled = true;
			}

			if(pauseState){
				Time.timeScale = 0;
			Cursor.visible = true;
				//GameObject.Find("Main Camera").GetComponent(SmoothMouseLook).enabled = false;
				//GameObject.Find("FirstPersonController").GetComponent(MouseLook).enabled = false;
			}

			if(pauseState == false && !player.is_dead()){
				Time.timeScale = 1;

			Cursor.visible = false;
				//GameObject.Find("Main Camera").GetComponent(SmoothMouseLook).enabled = true;
				//GameObject.Find("FirstPersonController").GetComponent(MouseLook).enabled = true;
				pauseMenu1.enabled = false;
			}

		}
		public void StartPress(){
			Application.LoadLevel(1);
			Cursor.visible = false;
	

		}

		public void ExitPress(){
			Debug.Log ("Game Exited");
			Application.Quit ();
		}


	}


