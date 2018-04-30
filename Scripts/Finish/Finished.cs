using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
	Class manages player/enemy movement when player/enemy has reached the finish
*/
public class Finished : MonoBehaviour {

	public GameObject body, ball;

	/*
		param col: the finish collider wich the player/enemy enters
		Edit player/enemy movement when player/enemy reaches the finish
	*/
	void OnTriggerEnter2D(Collider2D col){
		if(col.tag == "PlayerBall"){
			body.GetComponent<PlayerMovement>().finished = true;
		}else if(col.tag == "EnemyBall"){
			body.GetComponent<EnemyMovement>().finished = true;
		}

		ball.GetComponent<BallMovement>().finished = true;
	}
}
