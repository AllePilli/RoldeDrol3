using UnityEngine;

public class CameraFollow : MonoBehaviour {
	public Transform target_a;
	public Vector3 offset_a;

	private Vector3 initialPosition;

	void Start(){
		initialPosition = GetComponent<Transform>().position;
	}

	void LateUpdate(){
		Vector3 pos = new Vector3(target_a.position.x, initialPosition.y, 0);
		transform.position = pos + offset_a;
	}
}
