using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
	Class starts the race when the player is in the right position
*/
public class StartBehaviour : MonoBehaviour {

	public GameObject countdown;

	private bool firstTime;

	/*
		initialises data members
	*/
	void Start () {
		firstTime = true;
	}

	/*
		param col: Start flag collider
		Starts the countdown animation and sound when the player enters
		the start flag collider
	*/
	void OnTriggerEnter2D(Collider2D col){
		if(col.tag == "Player" && firstTime){
			countdown.GetComponent<CountdownBehaviour>().StartAnimation();
			FindObjectOfType<AudioManager>().Play("Countdown");
			firstTime = false;
		}
	}
}
