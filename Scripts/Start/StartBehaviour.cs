using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartBehaviour : MonoBehaviour {

	public GameObject countdown;

	void Start () {

	}

	void Update () {

	}

	void OnTriggerEnter2D(Collider2D col){
		countdown.GetComponent<CountdownBehaviour>().StartAnimation();
	}
}
