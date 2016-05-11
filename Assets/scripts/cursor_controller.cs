using UnityEngine;
using System.Collections;

public class cursor_controller : MonoBehaviour {

    public death player;

    private bool dead;
    private int count;

	void Start () {
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
        dead = false;
        count = 0;
	}

	public void curser_lock(){
		if(Cursor.lockState == CursorLockMode.Locked){
			Cursor.lockState = CursorLockMode.None;
		}
		else{
			Cursor.lockState = CursorLockMode.Locked;
		}
		Cursor.visible = !Cursor.visible;	
	}
	
	// Update is called once per frame
	void Update () {
        dead = player.is_dead();
	    if(Input.GetButtonDown("Cancel") && !dead){
            curser_lock();
        }

        if(dead && count <= 0) {
            curser_lock();
            count++;
        }
	}
}
