using UnityEngine;
using UnityEngine.UI;

//this script is used to activate, walk through and finish the tutorial
public class Tutorial : MonoBehaviour {

	public CanvasGroup panel;

	public Image[] tutorialImages;
	private int tutorialCurrent = 0;
	public int tutorialViewCount = 3;

	private bool playTutorial;
	private bool playDelayed;

	void Awake(){
		panel = GetComponent<CanvasGroup> ();
		panel.Deactivate ();
	}

	void Start(){
		GameManager.instance.onTutorialReady += ActivateTutorial;
	}

	void ActivateTutorial(){
		//make sure we can't view it twice:
		playTutorial = true;
		GameManager.instance.onTutorialReady -= ActivateTutorial;
		panel.Activate ();
		tutorialImages = GetComponentsInChildren<Image> (true);
		tutorialImages [0].gameObject.SetActive (true);
	}

	void Update (){
		if (playTutorial != playDelayed) {
			playDelayed = playTutorial;
			return;
		}

		if (playTutorial && Input.GetMouseButtonUp(0)) {
			Continue();
		}
	}

	void Continue(){
		tutorialImages [tutorialCurrent].gameObject.SetActive (false);
		tutorialCurrent++;
		if (tutorialCurrent == tutorialViewCount) {
			FinishTutorial ();
		} else {
			tutorialImages [tutorialCurrent].gameObject.SetActive (true);
		}
	}


	void FinishTutorial(){
		GameManager.instance.StartPlaying ();
		playTutorial = false;
		panel.Deactivate ();		
	}
}
