using UnityEngine;
using System.Collections;

public class cursor_controller : MonoBehaviour {

	void Start () {
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
	}

	void curser_lock(){
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
	    if(Input.GetButtonDown("Cancel")){ 
        	curser_lock(); 
        }
	}
}
