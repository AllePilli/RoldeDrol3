using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour {

	private Rigidbody2D ball;
	private AudioManager audioManager;

	public bool finished;

	void Start () {
		ball = GetComponent<Rigidbody2D>();
		audioManager = FindObjectOfType<AudioManager>();
	}

	void Update () {
		if(finished){
			ball.velocity = new Vector2(0f, 0f);
		}

		if(ball.tag == "PlayerBall"){
			if(Mathf.Abs(ball.velocity.x) > 0.01){
				if(!audioManager.IsPlaying("PlayerRoll")){
					audioManager.Play("PlayerRoll");
				}
			}else{
				if(audioManager.IsPlaying("PlayerRoll")){
					audioManager.Stop("PlayerRoll");
				}
			}
		}else{
			if(Mathf.Abs(ball.velocity.x) > 0.01){
				if(!audioManager.IsPlaying("EnemyRoll")){
					audioManager.Play("EnemyRoll");
				}
			}else{
				if(audioManager.IsPlaying("EnemyRoll")){
					audioManager.Stop("EnemyRoll");
				}
			}
		}
	}
}
