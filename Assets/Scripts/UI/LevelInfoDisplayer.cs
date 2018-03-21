using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.Events;

//handles the start info
//evaluates the achievements of the player
//shows the ending info
public class LevelInfoDisplayer : MonoBehaviour {

	public CanvasGroup startInfoPanel;
	public CanvasGroup endInfoPanel;

	private UnityAction startPlayingAction;

	private FishPoolDisplayer[] poolDisplays;

	public Text dockFeedbackText;

	public GameObject continueButton;
	public GameObject restartButton;

	void Start(){
		poolDisplays = GetComponentsInChildren<FishPoolDisplayer> ();

		startInfoPanel.Deactivate ();
		endInfoPanel.Deactivate ();
	}

	public void ShowLevelInfo(UnityAction startPlaying){
		startInfoPanel.Activate ();
		startPlayingAction = startPlaying;
	}

	public void DeactivateStartInfo(){
		startPlayingAction ();
		startInfoPanel.Deactivate ();
	}

	//Show results
	public void ShowResults(FishPoolInfo[] info, string dockFeedback, bool canContinue){
		endInfoPanel.Activate ();

		for (int i = 0; i < info.Length; i++) {
			poolDisplays [i].Activate (info [i]);
		}

		dockFeedbackText.text = dockFeedback;

		if (!canContinue) {
			restartButton.SetActive (true);
			continueButton.SetActive (false);
		}
		else {
			restartButton.SetActive (false);
			continueButton.SetActive (true);
		}
	}

	public void Continue(){
		endInfoPanel.Deactivate ();
		for (int i = 0; i < poolDisplays.Length; i++) {
			poolDisplays [i].Deactivate ();
		}

		GameManager.instance.LoadNextLevel ();
	}
}
