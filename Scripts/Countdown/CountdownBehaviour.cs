using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
	Class manages the countdown animation and
	player/enemy movement to get a correct start of the game
*/
public class CountdownBehaviour : MonoBehaviour {

	private Animator animator;
	private Transform transform;
	private Vector3 initialPosition;

	public GameObject player, enemy;
	public Transform camera;

	/*
		initialises data members
	*/
	void Start () {
		animator = GetComponent<Animator>();
		transform = GetComponent<Transform>();

		//countdown object sits outside of the camera view when it is not needed
		initialPosition = new Vector3(6.2f, 26.8f, 0f);
	}

	/*
		Starts the countdown animation, places the
		countdown object in the middle of the camera view and
		freezes the players movement while counting down
	*/
	public void StartAnimation(){
		animator.SetBool("startCountdown", true);
		transform.position = new Vector3(camera.position.x, camera.position.y, 0f);
		player.GetComponent<PlayerMovement>().frozen = true;
	}

	/*
		Stops the countdown animation, moves countdown object back out of sight
		and makes sure player and enemy can start walking
	*/
	public void EndAnimation(){
		animator.SetBool("startCountdown", false);
		transform.position = initialPosition;

		player.GetComponent<PlayerMovement>().frozen = false;
		player.GetComponent<PlayerMovement>().started = true;
		enemy.GetComponent<EnemyMovement>().started = true;
	}
}
