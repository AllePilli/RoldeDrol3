using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour {

	private Rigidbody2D ball;

	public bool finished;

	void Start () {
		ball = GetComponent<Rigidbody2D>();
	}

	void Update () {
		if(finished){
			ball.velocity = new Vector2(0f, 0f);
		}
	}
}
