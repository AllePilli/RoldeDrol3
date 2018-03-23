using UnityEngine;

public class Timer{
	//Bron: https://coffeebraingames.wordpress.com/2014/10/20/a-generic-duration-timer-class/
	private float polledTime;
	private float duration;

	public Timer(float duration){
		Reset(duration);
	}

	public void Update(){
		polledTime += Time.deltaTime;
	}

	public void Reset(){
		polledTime = 0;
	}

	public void Reset(float duration){
		Reset();
		this.duration = duration;
	}

	public bool Done(){
		return Comparison.TolerantGreaterThanOrEquals(polledTime, duration);
	}

	public float GetPolledTime(){
		return polledTime;
	}

	public float GetDuration(){
		return duration;
	}
}
