using UnityEngine;

public static class Comparison{
	//Bron: https://coffeebraingames.wordpress.com/2013/12/18/a-generic-floating-point-comparison-class/
	//Wordt gebruikt om floats met elkaar te vergelijken zonder onverwachte fouten

	//Returns a == b
	public static bool TolerantEquals(float a, float b){
		return Mathf.Approximately(a, b);
	}

	//Returns a >= b
	public static bool TolerantGreaterThanOrEquals(float a, float b){
		return a > b || TolerantEquals(a, b);
	}

	//Returns a <= break;
	public static bool TolerantLessThanOrEquals(float a, float b){
		return a < b || TolerantEquals(a, b);
	}
}
