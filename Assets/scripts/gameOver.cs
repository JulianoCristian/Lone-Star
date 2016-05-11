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

	// Use this for initialization
	void Start () {
        gameOverMenu1 = gameOverMenu1.GetComponent<Canvas> ();
		startText = startText.GetComponent<Button> ();
		exitText = exitText.GetComponent<Button> ();

        gameOverMenu1.enabled = false;
        death_state = false;
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

	public void StartPress(){
		Application.LoadLevel(1);
		Cursor.visible = false;
        death_state = false;
	}

	public void ExitPress(){
		Debug.Log ("Game Exited");
		Application.Quit ();
	}
}
