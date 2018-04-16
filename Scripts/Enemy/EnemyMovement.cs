using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

	//TODO: Bangers sdf font voor alle text

	public float minSpeed;
	public bool finished, started, firstTime;
	public Rigidbody2D player;

	private Rigidbody2D enemyBody;
	private Animator animator;
	private Vector2 initialPosition;
	private AudioManager audioManager;

	// Use this for initialization
	void Start () {
		enemyBody = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
		audioManager = FindObjectOfType<AudioManager>();

		initialPosition = enemyBody.position;
	}

	// Update is called once per frame
	void Update () {
		if(!finished && started){
			float playerVel = player.velocity.x;

			if(playerVel > minSpeed){
				enemyBody.velocity = new Vector2(playerVel * 1.15f, enemyBody.velocity.y);
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
