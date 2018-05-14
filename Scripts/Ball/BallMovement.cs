using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
	Class mainly makes sure that the rollin sound is played at the right time
*/
public class BallMovement : MonoBehaviour {

	private Rigidbody2D ball;
	private AudioManager audioManager;

	public bool finished;

	/*
		Initialises data members
	*/
	void Start () {
		ball = GetComponent<Rigidbody2D>();
		audioManager = FindObjectOfType<AudioManager>();
	}

	/*
		Uses instance of AudioManager to play/stop the rolling sounds
	*/
	void Update () {
		if(finished){
			ball.velocity = new Vector2(0f, 0f);
		}

		float s = ball.velocity.x;

		if(ball.tag == "PlayerBall"){
			// Absolute maximum ball speed = maximum player speed = 7.7
			s = (s > 7.7f) ? 7.7f : s;
			ball.velocity = new Vector2(s, ball.velocity.y);

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
			// Absolute maximum ball speed = maximum enemy speed = 7.78
			s = (s > 7.78f) ? 7.78f : s;
			ball.velocity = new Vector2(s, ball.velocity.y);

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
