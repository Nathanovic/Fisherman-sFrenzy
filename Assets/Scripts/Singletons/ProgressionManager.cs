using UnityEngine;
using System.Collections.Generic;

//handles the permit-system and evaluates the results of the player (whether he will continue to the next level or not!)
public class ProgressionManager : MonoBehaviour {

	public static ProgressionManager instance;

	private List<Permit> allPermits;

	private List<FishPool> fishPools = new List<FishPool>();
	public LevelInfoDisplayer canvasScript;
	public PlayerEconomics scoreScript;

	public event DefaultDelegate onGameOver;

	public AudioClip gameLostSound;

	public UnityEngine.UI.Image neutralBob;
	public UnityEngine.UI.Image angryBob;

	public LevelInfoDisplayer levelInfoScript;
	public SeasonDemand[] seasonDemands;
	public int currentSeason = 0;
	private int seasonDemandAmount;

	[Range(0f, 1f)][SerializeField]private float poolEndangeredPercentage;

	//evaluated values:
	[HideInInspector]public bool playerCanContinue;
	private int permitCount;
	private FishPoolInfo[] info;
	private int exterminatedCount;

	void Awake(){
		instance = this;
		PrepareNextSeason ();
	} 

	void PrepareNextSeason (){
		currentSeason++;

		if (currentSeason == seasonDemands.Length) {
			return;
		}

		SeasonDemand seasonDemand = seasonDemands [currentSeason - 1];
		seasonDemandAmount = seasonDemand.demand;
		levelInfoScript.SetDemandInfo (seasonDemand, currentSeason);
	}

	//called whenever a new permit is bought/on awake by permits that are already enabled
	public void AddPermit(Permit permit){
		fishPools.AddRange(permit.myFishPools);
	}

	public void EvaluateProgress(){
		permitCount = fishPools.Count;
		playerCanContinue = false;
		exterminatedCount = 0;

		info = new FishPoolInfo[permitCount];
		for (int i = 0; i < permitCount; i++) {
			bool _ext = false;
			info [i] = CreatePoolInfo (fishPools [i], out _ext);

			if (_ext) {
				exterminatedCount++;
			}
		}

		int maxValidExtCount = Mathf.FloorToInt ((float)permitCount / 2f);
		if (exterminatedCount > maxValidExtCount) {
			playerCanContinue = false;
		} else {
			int requiredCount = Mathf.FloorToInt ((float)seasonDemandAmount / 2f);
			if (scoreScript.SufficientScoreCount(requiredCount)) {
				playerCanContinue = true;
			} else {
				playerCanContinue = false;
			}
		}
	}

	public void ShowResults(){
		string dockFeedback = "feedback";
		int maxValidExtCount = Mathf.FloorToInt ((float)permitCount / 2f);
		if (exterminatedCount > maxValidExtCount) {
			dockFeedback = "You exterminated more than half of the fishing population, of course we can't let you fish here. \n" +
				"You will destroy the entire population!";
			GameOver ();
		} else {
			int requiredCount = Mathf.FloorToInt ((float)seasonDemandAmount / 2f);
			if (scoreScript.SufficientScoreCount(requiredCount)) {
				dockFeedback = "Okay, you've just got enough, you can continue if you want";
			} else {
				dockFeedback = "What?! You didn't even reach half our demand! \n" +
					"You cannot continue like this!";
				GameOver ();
			}
		}

		canvasScript.ShowResults (info, dockFeedback, playerCanContinue);
	}

	private void GameOver(){
		neutralBob.enabled = false;
		angryBob.enabled = true;

		AudioManager.instance.PlaySFX (gameLostSound);	

		if (onGameOver != null) {
			onGameOver ();
		}	
	}

	private FishPoolInfo CreatePoolInfo(FishPool fishPool, out bool exterminated){
		exterminated = false;
		FishPoolInfo poolInfo = new FishPoolInfo ();

		int remainedFish = fishPool.RemainingFishCount ();
		float fishPercentage = (float)remainedFish / fishPool.maxFishAmount;
		string fishPopulationHealth = "exterminated...";

		if (remainedFish < fishPool.minFishAmount) {
			exterminated = true;			
		}
		else if (FishPoolEndangered(fishPool)) {
			fishPopulationHealth = "endangered";
		}
		else {
			fishPopulationHealth = "stable";
		}

		fishPercentage *= 100f;
		poolInfo.poolText = fishPool.permitName + " - " + fishPool.fishName;
		poolInfo.infoText = fishPercentage.ToString("F2") + "% of this population survived";
		poolInfo.resultText = "Fish population health: " + fishPopulationHealth;

		return poolInfo;
	}

	public bool FishPoolEndangered(FishPool pool){
		float percentage = (float)pool.RemainingFishCount () / pool.maxFishAmount;
		return (percentage <= poolEndangeredPercentage);
	}

	//button event: 
	public void TryLoadNextSeason(){
		PrepareNextSeason ();
		levelInfoScript.DeactivateEndPanel();
		if (currentSeason == seasonDemands.Length) {
			GameManager.instance.ShowGameCompletion ();
		}
		else{
			GameManager.instance.StartNextSeason (currentSeason);				
		}
	}
}

public class FishPoolInfo{
	public string poolText;
	public string infoText;
	public string resultText;
}

[System.Serializable]
public class SeasonDemand {
	public int demand;
	[Header("use the '#' tag to insert the demand in the text")]
	public string demandText = "I want # KG from you!";
}
