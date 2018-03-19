using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finished : MonoBehaviour {

	public GameObject body, ball;

	void OnTriggerEnter2D(Collider2D col){
		if(col.tag == "PlayerBall"){
			body.GetComponent<PlayerMovement>().finished = true;
		}else if(col.tag == "EnemyBall"){
			body.GetComponent<EnemyMovement>().finished = true;
		}

		ball.GetComponent<BallMovement>().finished = true;
	}
}
