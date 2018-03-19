using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountdownBehaviour : MonoBehaviour {

	private Animator animator;
	private Transform transform;

	public GameObject player, enemy;

	void Start () {
		animator = GetComponent<Animator>();
		transform = GetComponent<Transform>();
	}

	void Update () {

	}

	public void StartAnimation(){
		animator.SetBool("startCountdown", true);
		transform.position = new Vector3(6.2f, 0f, 0f);
		player.GetComponent<PlayerMovement>().frozen = true;
	}

	void EndAnimation(){
		animator.SetBool("startCountdown", false);
		transform.position = new Vector3(6.2f, 26.8f, 0f);

		Physics2D.gravity = new Vector2(-1f, -9.81f);
		player.GetComponent<PlayerMovement>().frozen = false;
		enemy.GetComponent<EnemyMovement>().started = true;
	}
}
