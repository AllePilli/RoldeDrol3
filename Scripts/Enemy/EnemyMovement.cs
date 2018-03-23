using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

	public float speed;
	public bool finished, started;

	private Rigidbody2D enemyBody;
	private Animator animator;
	private Vector2 initialPosition;

	// Use this for initialization
	void Start () {
		enemyBody = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();

		initialPosition = enemyBody.position;
	}

	// Update is called once per frame
	void Update () {
		if(!finished && started){
			enemyBody.velocity = new Vector2(speed, enemyBody.velocity.y);
			animator.SetFloat("speed", Mathf.Abs(speed));
		}else{
			enemyBody.velocity = new Vector2(0f, 0f);
			animator.SetFloat("speed", 0f);
		}
	}

	/*public void Reset(){
		started = false;
		finished = false;

		enemyBody.position = initialPosition;
	}*/
}
