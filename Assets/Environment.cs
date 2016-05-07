using UnityEngine;
using System.Collections;

public class Environment : MonoBehaviour {

	public Material skybox;

	void Start () {
		RenderSettings.skybox = skybox;
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
	
    void Update() {

    }
}
