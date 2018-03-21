using UnityEngine;
using UnityEngine.SceneManagement;

//disable itself if this is not the only scene
public class DisableSelf : MonoBehaviour {

	void Start(){
		if (SceneManager.sceneCount > 1) {
			gameObject.SetActive (false);
		}
	}
}
