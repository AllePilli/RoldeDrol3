using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DebugText : MonoBehaviour {

	public Text text;
	public GameObject player;

	private bool DEMO;

	void Start () {
		//DEMO = player.GetComponent<PlayerMovement>().DEMO;
	}

	void Update () {
		/*if(DEMO){
			text.text = "" + player.GetComponent<PlayerMovement>().input;
		}else{
			text.text = player.GetComponent<PlayerMovement>().arduinoInput;
		}*/
		if(player.GetComponent<PlayerMovement>().serialClosed){
			text.text = "SerialPort is closed";
		}else{
			text.text = player.GetComponent<PlayerMovement>().arduinoInput;
		}
	}
}
