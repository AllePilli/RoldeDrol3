using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour {

	private Rigidbody2D playerBody;
	private Animator animator;
	private Vector2 initialPosition;
	private Timer timer;
	private AudioManager audioManager;
	private bool firstTime;
	private float finishTime;

	[SerializeField]
	private float maxSpeed, resetTime;

	public bool finished, frozen, started;
	public float input;
	public string arduinoInput, prevInput;
	public bool serialClosed;
	public Image image;

	/*Met Arduino*/
	// private SerialPort sp = new SerialPort("COM4", 9600);

	void Start () {
		playerBody = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
		timer = new Timer(resetTime);
		audioManager = FindObjectOfType<AudioManager>();
		firstTime = true;
		finishTime = 0f;

		initialPosition = playerBody.position;

		/*Met Arduino*/
		// sp.Open();
		// sp.ReadTimeout = 35;
	}

	void Update () {
		/*Met Arduino*/
		// if(sp.IsOpen){
		// 	try {
		// 		arduinoInput = sp.ReadLine();
		// 	}catch (System.Exception) {
		// 		arduinoInput = prevInput;
		// 	}
		// }else{
		// 	serialClosed = true;
		// }


		// prevInput = arduinoInput;
		// HandleMovement(float.Parse(arduinoInput));

		float input = Input.GetAxis("Horizontal");
		HandleMovement(input);

		if(started && Comparison.TolerantEquals(playerBody.velocity.x, 0) && !finished){
			timer.Update();

			if(timer.Done()){
				SceneManager.LoadScene(SceneManager.GetActiveScene().name);
			}
		}else{
			timer.Reset();
		}

		if(frozen && firstTime){
			firstTime = false;
			Show(0);
		}

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
				}else if(time < 40){
					Show(6);
				}else{
					SceneManager.LoadScene(SceneManager.GetActiveScene().name);
				}
			}
		}
	}

	private void HandleMovement(float f){
		if(!finished && !frozen){
			if (f > 0) {
				playerBody.velocity = new Vector2(1.15f * f * maxSpeed, playerBody.velocity.y);
			}

			animator.SetFloat("speed", Mathf.Abs(f));
		}else{
			playerBody.velocity = new Vector2(0f, 0f);
			animator.SetFloat("speed", 0f);
		}
	}

	private void Show(int index){
		image.GetComponent<ImageSwitch>().Show(index);
	}
}
