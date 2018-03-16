using UnityEngine;

public class CameraFollow : MonoBehaviour {
	public Transform target_a;
	public Vector3 offset_a;

	void LateUpdate(){
		Vector3 pos = new Vector3(target_a.position.x, target_a.position.y, 0);
		transform.position = pos + offset_a;
		//transform.LookAt(target);
	}
}
