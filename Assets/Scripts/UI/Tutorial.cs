using UnityEngine;
using UnityEngine.UI;

//this script is used to activate, walk through and finish the tutorial
public class Tutorial : MonoBehaviour {

	public CanvasGroup panel;

	public Image[] tutorialImages;
	private int tutorialCurrent = 0;
	public int tutorialViewCount = 3;

	void Awake(){
		panel = GetComponent<CanvasGroup> ();
		panel.Deactivate ();
	}

	void Start(){
		GameManager.instance.onGameStarted += ActivateTutorial;
	}

	void ActivateTutorial(){
		Debug.Log ("activate tutorial!");
		GameManager.instance.DisableBoatControls ();
		panel.Activate ();
		tutorialImages = GetComponentsInChildren<Image> (true);
		tutorialImages [0].gameObject.SetActive (true);
	}

	void Update(){
		if (panel.alpha == 0) {
			Debug.Log (" panel deactivated");
			return;
		}

		if (ShipInputManager.instance.pointerUp) {
			Debug.Log (" continue");
			Continue();
		}
	}

	public void Continue(){
		tutorialImages [tutorialCurrent].gameObject.SetActive (false);
		tutorialCurrent++;
		if (tutorialCurrent == tutorialViewCount) {
			panel.Deactivate ();
			GameManager.instance.EnableBoatControls ();
		} else {
			tutorialImages [tutorialCurrent].gameObject.SetActive (true);
		}
	}
}
