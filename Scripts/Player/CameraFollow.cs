using UnityEngine;

/*
	Class makes sure the target is always in the same place in the camera view
*/
public class CameraFollow : MonoBehaviour {
	public Transform target_a;
	public Vector3 offset_a;

	private Vector3 initialPosition;

	/*
		initialises data members
	*/
	void Start(){
		initialPosition = GetComponent<Transform>().position;
	}

	/*
		Moves camera so the target stays in the same
		position in the camera view
	*/
	void LateUpdate(){
		Vector3 pos = new Vector3(target_a.position.x, initialPosition.y, 0);
		transform.position = pos + offset_a;
	}
}
