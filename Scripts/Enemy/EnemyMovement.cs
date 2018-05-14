using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
	Class Manages the enemy movement
*/
public class EnemyMovement : MonoBehaviour {

	public float minSpeed;
	public bool finished, started, firstTime;
	public Rigidbody2D player;

	private Rigidbody2D enemyBody;
	private Animator animator;
	private Vector2 initialPosition;
	private AudioManager audioManager;

	/*
		initialises data members
	*/
	void Start () {
		enemyBody = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
		audioManager = FindObjectOfType<AudioManager>();

		initialPosition = enemyBody.position;
	}

	/*
		Updates the enemy speed according to the players speed(always 1% quicker than player),
		Forwards speed to the animator and plays the "finished" sound when race is over
	*/
	void Update () {
		if(!finished && started){
			float playerVel = player.velocity.x;

			if(playerVel > minSpeed){
				enemyBody.velocity = new Vector2(playerVel * 1.01f, enemyBody.velocity.y);
				animator.SetFloat("speed", Mathf.Abs(playerVel * 1.15f));
			}else{
				enemyBody.velocity = new Vector2(minSpeed, enemyBody.velocity.y);
				animator.SetFloat("speed", Mathf.Abs(minSpeed));
			}
		}else{
			enemyBody.velocity = new Vector2(0f, 0f);
			animator.SetFloat("speed", 0f);
		}

		if(finished && !firstTime){
			audioManager.Play("Finish");
			firstTime = true;
		}
	}
}
