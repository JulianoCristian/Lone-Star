using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class timer : MonoBehaviour {
    float total_time = 0;
    public Text timer_text;


	// Use this for initialization
	void Start () {
	    timer_text.text = "Timer: " + total_time.ToString("#.00");
	}
	
	// Update is called once per frame
	void Update () {
        total_time = total_time + Time.deltaTime;
	    timer_text.text = "Timer: " + total_time.ToString("#.00");
	}

    public float get_total_time() {
        return total_time;
    }
}
