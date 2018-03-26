using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	private Rigidbody2D playerBody;
	private Animator animator;
	public string arduinoInput, prevInput;
	private Vector2 initialPosition;
	private Timer timer;
	private AudioManager audioManager;
	//private SerialPort sp;

	[SerializeField]
	private float maxSpeed, resetTime;

	public bool finished, frozen, started;
	public float input;
	public bool DEMO = false;
	public bool serialClosed;

	//Met Arduino
	private SerialPort sp = new SerialPort("COM4", 9600);
	//private SerialPort sp = new SerialPort("COM5", 9600);


	void Start () {
		playerBody = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
		timer = new Timer(resetTime);
		audioManager = FindObjectOfType<AudioManager>();

		initialPosition = playerBody.position;

		/*Met Arduino
		if(!DEMO){
			sp = new SerialPort("COM4", 9600);
			sp.Open();
			sp.ReadTimeout = 1;
		}*/

		sp.Open();
		sp.ReadTimeout = 55;// 1
	}

	// Update is called once per frame
	void Update () {
		/*Met Arduino
		if(!DEMO){
			if(sp.IsOpen){
				try {
					//arduinoInput = sp.ReadByte();
					arduinoInput = sp.ReadLine();
				}catch (System.Exception) {
					throw;
				}
			}
		}*/

		if(sp.IsOpen){
			try {
				//arduinoInput = sp.ReadByte();
				arduinoInput = sp.ReadLine();
			}catch (System.Exception) {
				arduinoInput = prevInput;
			}
		}else{
			serialClosed = true;
		}

		if(started && (Comparison.TolerantEquals(playerBody.velocity.x, 0) || finished)){
			timer.Update();

			if(timer.Done()){
				SceneManager.LoadScene(SceneManager.GetActiveScene().name);
			}
		}else{
			timer.Reset();
		}

		/*if(DEMO){
			input = Input.GetAxis("Horizontal");
			HandleMovement(input);
		}else{
			HandleMovement(float.Parse(arduinoInput));
		}*/
		prevInput = arduinoInput;
		HandleMovement(float.Parse(arduinoInput));
	}

	private void HandleMovement(float f){
		if(!finished && !frozen){
			if (f > 0) {
				playerBody.velocity = new Vector2(f * maxSpeed, playerBody.velocity.y);
			}

			animator.SetFloat("speed", Mathf.Abs(f));
		}else{
			playerBody.velocity = new Vector2(0f, 0f);
			animator.SetFloat("speed", 0f);
		}
	}
}
