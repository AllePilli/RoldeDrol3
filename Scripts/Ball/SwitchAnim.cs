using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*-Script wordt gebruikt door Ball object*/

public class SwitchAnim : MonoBehaviour {

	public Animator animator;
	public Rigidbody2D ball;

	void OnTriggerEnter2D(Collider2D col){
		if(col.tag == "Enemy" || col.tag == "Player"){
			animator.SetBool("pushing", true);
		}
	}

	void OnTriggerExit2D(Collider2D col){
		if(col.tag == "Enemy" || col.tag == "Player"){
			animator.SetBool("pushing", false);
		}
	}
}
