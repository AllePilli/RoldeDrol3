using UnityEngine;

/*
	Class compares floats without making unexpected errors
*/
public static class Comparison{
	//Bron: https://coffeebraingames.wordpress.com/2013/12/18/a-generic-floating-point-comparison-class/

	/*
		param a, b: floating numbers to be compared
		return : true if a = b within tolerance ranges
	*/
	public static bool TolerantEquals(float a, float b){
		return Mathf.Approximately(a, b);
	}

	/*
		param a, b: floating numbers to be compared
		return : true if a >= b within tolerance ranges
	*/
	public static bool TolerantGreaterThanOrEquals(float a, float b){
		return a > b || TolerantEquals(a, b);
	}

	/*
		param a, b: floating numbers to be compared
		return : true if a <= b within tolerance ranges
	*/
	public static bool TolerantLessThanOrEquals(float a, float b){
		return a < b || TolerantEquals(a, b);
	}
}
