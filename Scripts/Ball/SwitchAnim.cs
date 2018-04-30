using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
	Class changes animations when player/enemy pushes the ball
*/
public class SwitchAnim : MonoBehaviour {

	public Animator animator;
	public Rigidbody2D ball;

	/*
		param col: ball collider wich player/enemy enters
		Starts the pushing animation when the player or enemy touches the ball
	*/
	void OnTriggerEnter2D(Collider2D col){
		if(col.tag == "Enemy" || col.tag == "Player"){
			animator.SetBool("pushing", true);
		}
	}

	/*
		param col: ball collider wich player/enemy exits
		Stops the pushing animation when the player or enemy stops touching the ball
	*/
	void OnTriggerExit2D(Collider2D col){
		if(col.tag == "Enemy" || col.tag == "Player"){
			animator.SetBool("pushing", false);
		}
	}
}
