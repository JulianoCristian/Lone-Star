using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class mainMenu : MonoBehaviour {

	public Canvas mainMenu1;
	public Button startText;
	public Button exitText;


	private bool pauseState;

	// Use this for initialization
	void Start () {
	
		mainMenu1 = mainMenu1.GetComponent<Canvas> ();
		startText = startText.GetComponent<Button> ();
		exitText = exitText.GetComponent<Button> ();

		Cursor.visible = true;

	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void StartPress(){
		Application.LoadLevel(1);
		Cursor.visible = false;
		mainMenu1.enabled = false;

	}

	public void ExitPress(){
		Debug.Log ("Game Exited");
		Application.Quit ();
	}
		

}
