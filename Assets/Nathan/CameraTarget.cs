using UnityEngine;

public class CameraTarget : MonoBehaviour {

	void Start(){
		Camera.main.GetComponent<CameraViewController> ().StartTracking (transform);
	}
}
