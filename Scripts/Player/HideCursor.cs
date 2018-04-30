using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
	Class hides the cursor
*/
public class HideCursor : MonoBehaviour {

	/*
		Makes the cursor invisible
	*/
	void Awake () {
		Cursor.visible = false;
	}
}
