using UnityEngine;

/*
	Class used to execute code after a certain duration of time
*/
public class Timer{
	//Bron: https://coffeebraingames.wordpress.com/2014/10/20/a-generic-duration-timer-class/
	private float polledTime;
	private float duration;

	/*
		param duration: amount of time to count down
		Constructor for Timer class
	*/
	public Timer(float duration){
		Reset(duration);
	}

	/*
		Updates the polled time
	*/
	public void Update(){
		polledTime += Time.deltaTime;
	}

	/*
		Resets the timer
	*/
	public void Reset(){
		polledTime = 0;
	}

	/*
		Resets the timer and edits the timer duration
	*/
	public void Reset(float duration){
		Reset();
		this.duration = duration;
	}

	/*
		return: true when the timer is done counting down
	*/
	public bool Done(){
		return Comparison.TolerantGreaterThanOrEquals(polledTime, duration);
	}

	/*
		return : The counted time until this moment
	*/
	public float GetPolledTime(){
		return polledTime;
	}

	/*
		return: the duration of the timer
	*/
	public float GetDuration(){
		return duration;
	}
}
