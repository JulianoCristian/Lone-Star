using UnityEngine;
using System.Collections;

public class enemy_lives : MonoBehaviour {

    public int life_total;
    private int life;


	void Start () {
	    life = life_total;
	}

    void OnEnable(){
        life = life_total;
    }

    public void life_subtract(){
        life = life - 1;
    }
	
	void Update () {
        if(life <= 0){
            gameObject.SetActive(false);
        }
	}
}
