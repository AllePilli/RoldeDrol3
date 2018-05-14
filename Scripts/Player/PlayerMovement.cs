using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using System.IO;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

/*
	Class handles the movement of the player,
	serial communication with Arduino
	and the informative textchanges
*/
public class PlayerMovement : MonoBehaviour {

	private Rigidbody2D playerBody;
	private Animator animator;
	private Vector2 initialPosition;
	private Timer timer;
	private AudioManager audioManager;
	private bool firstTime;
	private float finishTime;

	[SerializeField]
	/*
		maxSpeed : the maximum speed the player can walk
		resetTime : the amount of time, if the player is in idle, after wich the game resets
	*/
	private float maxSpeed, resetTime;

	public bool finished, frozen, started, serialClosed;
	public float input;
	public string arduinoInput, prevInput;

	/*
		Image used for informative text
	*/
	public Image image;

	/*Met Arduino*/
	private SerialPort sp;
	/*-----------*/

	/*
		Instantiates all data members and opens serial connection
	*/
	void Start () {
		/*Met Arduino*/
		sp = new SerialPort(readCOM(), 9600);
		/*-----------*/

		playerBody = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
		timer = new Timer(resetTime);
		audioManager = FindObjectOfType<AudioManager>();
		firstTime = true;
		finishTime = 0f;

		initialPosition = playerBody.position;

		/*Met Arduino*/
		sp.Open();
		sp.ReadTimeout = 35;
		/*-----------*/
	}

	/*
		reads Arduino input, resets game if player goes idle and
		handles state machine for the informative text changes
	*/
	void Update () {
		/*Met Arduino*/
		if(sp.IsOpen){
			try {
				arduinoInput = sp.ReadLine();
				arduinoInput = (arduinoInput > 1.1) ? 1.1 : arduinoInput;
			}catch (System.Exception) {
				arduinoInput = prevInput;
			}
		}else{
			serialClosed = true;
		}


		prevInput = arduinoInput;
		HandleMovement(float.Parse(arduinoInput));
		/*----------*/

		/*Zonder Arduino*/
		// float input = Input.GetAxis("Horizontal");
		// HandleMovement(input);
		/*--------------*/


		//handles game reset if player goes idle
		if(started && Comparison.TolerantLessThanOrEquals(playerBody.velocity.x, 0.05f) && !finished){
			timer.Update();

			if(timer.Done()){
				SceneManager.LoadScene(SceneManager.GetActiveScene().name);
			}
		}else{
			timer.Reset();
		}

		//changes text when the race started
		if(frozen && firstTime){
			firstTime = false;
			Show(0);
		}

		//state machine for informative text changes
		if(finished){
			if(!Comparison.TolerantGreaterThanOrEquals(finishTime, 0.5f)){
				finishTime = Time.time;
			}else{
				float time = Time.time - finishTime;

				if(time < 4){
					Show(1);
				}else if(time < 12){
					Show(2);
				}else if(time < 20){
					Show(3);
				}else if(time < 28){
					Show(4);
				}else if(time < 36){
					Show(5);
				}else if(time < 44){
					Show(6);
				}else if(time < 52){
					Show(7);
				}else{
					SceneManager.LoadScene(SceneManager.GetActiveScene().name);
				}
			}
		}
	}

	/*
		param f: float between 0.0 and 1.0 representing a percentage of maxSpeed
		uses a float to change the players velocity
	*/
	private void HandleMovement(float f){
		if(!finished && !frozen){
			if (f > 0) {
				// Absolute maximum player speed = 7.7
				float s = 1.40f * f * maxSpeed;
				s = (s > 7.7f) ? 7.7f : s; 
				playerBody.velocity = new Vector2(s, playerBody.velocity.y);
			}

			animator.SetFloat("speed", Mathf.Abs(f));
		}else{
			playerBody.velocity = new Vector2(0f, 0f);
			animator.SetFloat("speed", 0f);
		}
	}

	/*
		param index: index of picture to be shown
		switches the shown picture in image with the desired picture
	*/
	private void Show(int index){
		image.GetComponent<ImageSwitch>().Show(index);
	}

	/*
		reads the COM.txt file in the data folder to get the desired COM port
		return : string representing the COM port
	*/
	private string readCOM(){
		try{
			StreamReader reader = new StreamReader(Application.dataPath + "/COM.txt");
			string COM = reader.ReadToEnd();
			reader.Close();
			return COM;
		}catch{
			string COM = "COM4";
			return COM;
		}
	}
}
