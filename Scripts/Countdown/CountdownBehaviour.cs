using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountdownBehaviour : MonoBehaviour {

	private Animator animator;
	private Transform transform;
	private Vector3 initialPosition;

	public GameObject player, enemy;
	public Transform camera;

	void Start () {
		animator = GetComponent<Animator>();
		transform = GetComponent<Transform>();
		initialPosition = new Vector3(6.2f, 26.8f, 0f);
	}

	public void StartAnimation(){
		animator.SetBool("startCountdown", true);
		transform.position = new Vector3(camera.position.x, camera.position.y, 0f);
		player.GetComponent<PlayerMovement>().frozen = true;
	}

	public void EndAnimation(){
		animator.SetBool("startCountdown", false);
		transform.position = initialPosition;

		player.GetComponent<PlayerMovement>().frozen = false;
		player.GetComponent<PlayerMovement>().started = true;
		enemy.GetComponent<EnemyMovement>().started = true;
	}
}
