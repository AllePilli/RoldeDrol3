using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Freeze : MonoBehaviour {

	public Rigidbody2D body;

	void Start () {

	}

	void OnTriggerEnter2D(Collider2D col){
		if(col.tag == "Player" || col.tag == "Enemy"){
			body.velocity = new Vector2(0f, 0f);
		}
	}
}
