using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

	public Rigidbody2D player;
	private Rigidbody2D enemyBody;
	private Animator animator;

	[SerializeField]
	private float percentage;

	// Use this for initialization
	void Start () {
		enemyBody = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update () {
		HandleMovement();
	}

	void HandleMovement(){
		float vel = player.velocity.x * percentage;
		enemyBody.velocity = new Vector2(vel, enemyBody.velocity.y);
		animator.SetFloat("speed", Mathf.Abs(vel));
	}
}
