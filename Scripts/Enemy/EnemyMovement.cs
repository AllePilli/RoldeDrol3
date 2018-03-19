﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

	public float speed;
	public bool finished;

	private Rigidbody2D enemyBody;
	private Animator animator;

	// Use this for initialization
	void Start () {
		enemyBody = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update () {
		if(!finished){
			enemyBody.velocity = new Vector2(speed, enemyBody.velocity.y);
			animator.SetFloat("speed", Mathf.Abs(speed));
		}else{
			enemyBody.velocity = new Vector2(0f, 0f);
			animator.SetFloat("speed", 0f);
		}
	}
}
