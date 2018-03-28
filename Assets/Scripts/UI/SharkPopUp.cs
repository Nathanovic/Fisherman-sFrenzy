using UnityEngine;
using UnityEngine.Events;

//this script manages the shark pop up stuff (activation & sel/release)
internal class SharkPopUp : MonoBehaviour {

	private CanvasGroup cvg;
	private EndangeredFish fish;

	[SerializeField]private CanvasGroup choicePanel;
	[SerializeField]private CanvasGroup luckyResultPanel;
	[SerializeField]private CanvasGroup badResultPanel;

	private UnityAction<int> feedbackCallback;
	[SerializeField]private int succesReward = 20;
	[SerializeField]private int punishment = 40;
	[SerializeField]private float succesChance = 0.6f;
	[SerializeField]private float succesChanceMultiplier = 0.75f;

	void Start(){
		cvg = GetComponent<CanvasGroup> ();
		cvg.Deactivate ();
	}

	public void Activate(EndangeredFish _fish, UnityAction<int> _feedbackCallback){
		Debug.Log ("activate!");
		fish = _fish;
		fish.AttachToNet ();
		feedbackCallback = _feedbackCallback;
		GameManager.instance.DisableBoatControls ();
		cvg.Activate ();
		choicePanel.Activate ();
	}

	//random chance of succesfull sell, otherwise punish the player:
	public void Kill(){
		choicePanel.Deactivate ();
		fish.Kill ();

		float value = Random.value;
		Debug.Log ("Random value " + value.ToString("F2") + " against succeschance " + succesChance.ToString("F2"));
		if (value <= succesChance) {
			luckyResultPanel.Activate ();
			succesChance *= succesChanceMultiplier;
			feedbackCallback (succesReward);
		}
		else{
			badResultPanel.Activate ();
			feedbackCallback (-punishment);
		}
	}

	//release the shark:
	public void Release(){
		fish.Escape ();
		ContinuePlaying ();
	}

	public void ContinuePlaying(){
		fish = null;
		luckyResultPanel.Deactivate ();
		badResultPanel.Deactivate ();
		cvg.Deactivate ();
		GameManager.instance.EnableBoatControls ();
	}
}
