using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.Events;

//handles the start info
//evaluates the achievements of the player
//shows the ending info
public class LevelInfoDisplayer : MonoBehaviour {

	private CanvasGroup cvg;
	public CanvasGroup startInfoPanel;
	public CanvasGroup endInfoPanel;

	private UnityAction startPlayingAction;

	private FishPoolDisplayer[] poolDisplays;

	public Text dockFeedbackText;

	public GameObject continueButton;
	public GameObject restartButton;

	public Text seasonText;
	public Text demandText;

	void Start(){
		cvg = GetComponent<CanvasGroup> ();
		cvg.Deactivate ();

		poolDisplays = GetComponentsInChildren<FishPoolDisplayer> ();

		startInfoPanel.Deactivate ();
		endInfoPanel.Deactivate ();
	}

	public void SetDemandInfo(SeasonDemand demand, int season){
		string[] splittedDemandText = demand.demandText.Split("#"[0]);
		string demandText = splittedDemandText [0] + demand.demand.ToString () + splittedDemandText [1];
		string seasonText = "Season " + season.ToString ();
		this.seasonText.text = seasonText;
		this.demandText.text = demandText;
	}

	public void ShowLevelInfo(UnityAction startPlaying){
		cvg.Activate ();
		startInfoPanel.Activate ();
		startPlayingAction = startPlaying;
	}

	public void DeactivateStartInfo(){
		cvg.Deactivate ();
		startPlayingAction ();
		startInfoPanel.Deactivate ();
	}

	//Show results
	public void ShowResults(FishPoolInfo[] info, string dockFeedback, bool canContinue){
		cvg.Activate ();
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

	public void DeactivateEndPanel(){
		cvg.Deactivate ();
		endInfoPanel.Deactivate ();
		for (int i = 0; i < poolDisplays.Length; i++) {
			poolDisplays [i].Deactivate ();
		}
	}
}
