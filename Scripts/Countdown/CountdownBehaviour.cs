using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountdownBehaviour : MonoBehaviour {

	private Animator animator;
	private Transform transform;

	void Start () {
		animator = GetComponent<Animator>();
		transform = GetComponent<Transform>();
	}

	void Update () {

	}

	public void StartAnimation(){
		animator.SetBool("startCountdown", true);
		transform.position = new Vector3(6.2f, 0f, 0f);
	}

	void EndAnimation(){
		animator.SetBool("startCountdown", false);
		transform.position = new Vector3(6.2f, 26.8f, 0f);
	}
}
