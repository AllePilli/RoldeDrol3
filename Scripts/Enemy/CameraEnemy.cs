using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraEnemy : MonoBehaviour {
	public Transform player;
	public Vector3 offset_a;
	public float correction;

	private Vector3 initialPosition;

	/*
		initialises data members
	*/
	void Start () {
		initialPosition = GetComponent<Transform>().position;
	}

	// Update is called once per frame
	void Update () {
		Vector3 pos = new Vector3(player.position.x + correction, initialPosition.y, 0);
		transform.position = pos + offset_a;
	}
}
