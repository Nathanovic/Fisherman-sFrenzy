using UnityEngine;
using UnityEngine.SceneManagement;

//disable the camera if this is not the only scene
public class DisableCam : MonoBehaviour {

	void Start(){
		if (SceneManager.sceneCount > 1) {
			GetComponent<Camera> ().enabled = false;
		}
	}
}
