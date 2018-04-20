using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartBehaviour : MonoBehaviour {

	public GameObject countdown;

	private bool firstTime;

	void Start () {
		firstTime = true;
	}

	void OnTriggerEnter2D(Collider2D col){
		if(col.tag == "Player" && firstTime){
			countdown.GetComponent<CountdownBehaviour>().StartAnimation();
			FindObjectOfType<AudioManager>().Play("Countdown");
			firstTime = false;
		}
	}
}
