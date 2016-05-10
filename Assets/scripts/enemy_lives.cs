using UnityEngine;
using System.Collections;

public class enemy_lives : MonoBehaviour {

    public int life_total;
    private int life;
    private bool dead = false;

    private AudioSource death_sound;
    public float fade_time;


    public bool is_dead(){
        return dead;
    }

    public bool sound_playing(){
        return death_sound.isPlaying;
    }

	void Start () {
        death_sound = GetComponent<AudioSource>();
	    life = life_total;
        fade_time = 0.3f;

	}

    void OnEnable()
    {
        life = life_total;
        dead = false;

        if (gameObject.name.Contains("Rotate_Object")) {
            transform.parent.parent.parent.Find("GunPlat_1").GetComponent<MeshRenderer>().enabled = true;
            transform.parent.Find("Gun_2").GetComponent<SkinnedMeshRenderer>().enabled = true;
        }
        else if(gameObject.name.Contains("Enemy_new")) {
            transform.Find("PA_Drone").gameObject.SetActive(true);
        }
        else if(gameObject.name.Contains("enemy_ground_swarm_new")) {
            transform.Find("PA_Warrior").GetComponent<SkinnedMeshRenderer>().enabled = true;
        }
        else if(gameObject.name.Contains("enemyC_new")) {
            transform.Find("MeshContainer").gameObject.SetActive(true);
        }
        else {
            GetComponent<MeshRenderer>().enabled = true;
        }

        GetComponent<collision_detection>().enabled = true;
        GetComponent<BoxCollider>().enabled = true;
    }

    public void life_subtract(){
        life = life - 1;
    }
    
    void Update () {
        if(life <= 0 && !dead){
            dead = true;
            death_sound.Play();

            if (gameObject.name.Contains( "Rotate_Object")) {
                transform.parent.parent.parent.Find("GunPlat_1").GetComponent<MeshRenderer>().enabled = false;
                transform.parent.Find("Gun_2").GetComponent<SkinnedMeshRenderer>().enabled = false;
            }
            else if (gameObject.name.Contains( "Enemy_new")) {
                transform.Find("PA_Drone").gameObject.SetActive(false);
            }
            else if (gameObject.name.Contains( "enemy_ground_swarm_new")) {
                transform.Find("PA_Warrior").GetComponent<SkinnedMeshRenderer>().enabled = false;
            }
            else if (gameObject.name.Contains( "enemyC_new")) {
                transform.Find("MeshContainer").gameObject.SetActive(false);
            }
            else {
                GetComponent<MeshRenderer>().enabled = false;
            }

            GetComponent<collision_detection>().enabled = false;
            GetComponent<BoxCollider>().enabled = false;
        }
        if(dead && !death_sound.isPlaying){
            if (transform.parent != null)
                transform.parent.parent.parent.gameObject.SetActive(false);
            else
                gameObject.SetActive(false);
        }
	}
}
