using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*-Script wordt gebruikt door Ball object*/

public class SwitchAnim : MonoBehaviour {

	public Animator animator;

	void start(){

	}

	void update(){

	}

	void OnTriggerEnter2D(Collider2D col){
		if(col.tag == "Player"){
			animator.SetBool("pushing", true);
		}
	}

	void OnTriggerExit2D(Collider2D col){
		if(col.tag == "Player"){
			animator.SetBool("pushing", false);
		}
	}
}
