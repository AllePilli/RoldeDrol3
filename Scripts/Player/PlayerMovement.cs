using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	private Rigidbody2D playerBody;
	private Animator animator;

	private float arduinoInput;

	[SerializeField]
	private float maxSpeed;

	//Met Arduino
	//private SerialPort sp = new SerialPort("COM5", 9600);

	void Start () {
		playerBody = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();

		/*Met Arduino
		sp.Open();
		sp.ReadTimeout = 1;*/
	}

	// Update is called once per frame
	void Update () {
		/*Met Arduino
		if(sp.IsOpen){
			try {
				arduinoInput = sp.ReadByte();
			}catch (System.Exception) {
				throw;
			}

			playerBody.velocity = new Vector2(arduinoInput * maxSpeed, playerBody.velocity.y);
		}*/

		float input = Input.GetAxis("Horizontal");

		HandleMovement(input);
	}

	private void HandleMovement(float input){
		if (input > 0) {
			playerBody.velocity = new Vector2(input * maxSpeed, playerBody.velocity.y);
		}

		animator.SetFloat("speed", Mathf.Abs(input));
	}
}
