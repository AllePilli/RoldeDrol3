using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour {

	private Rigidbody2D playerBody;
	private Animator animator;
	private float arduinoInput;
	private Vector2 initialPosition;
	private Timer timer;

	[SerializeField]
	private float maxSpeed, resetTime;

	public bool finished, frozen, started;

	//Met Arduino
	//private SerialPort sp = new SerialPort("COM5", 9600);

	void Start () {
		playerBody = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
		timer = new Timer(resetTime);

		initialPosition = playerBody.position;

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

		if(started || (Comparison.TolerantEquals(playerBody.velocity.x, 0) || finished)){
			timer.Update();

			if(timer.Done()){
				SceneManager.LoadScene(SceneManager.GetActiveScene().name);
			}
		}else{
			timer.Reset();
		}

		float input = Input.GetAxis("Horizontal");

		HandleMovement(input);
	}

	private void HandleMovement(float input){
		if(!finished && !frozen){
			if (input > 0) {
				playerBody.velocity = new Vector2(input * maxSpeed, playerBody.velocity.y);
			}

			animator.SetFloat("speed", Mathf.Abs(input));
		}else{
			playerBody.velocity = new Vector2(0f, 0f);
			animator.SetFloat("speed", 0f);
		}
	}

	/*public void Reset(){
		finished = false;
		frozen = false;

		playerBody.position = initialPosition;
	}*/
}
