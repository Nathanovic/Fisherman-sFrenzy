using UnityEngine;
using System.Collections.Generic;

//handles the permit-system and evaluates the results of the player (whether he will continue to the next level or not!)
public class ProgressionManager : MonoBehaviour {

	public static ProgressionManager instance;

	private List<Permit> allPermits;

	private List<FishPool> fishPools = new List<FishPool>();
	public LevelInfoDisplayer canvasScript;
	public PlayerEconomics scoreScript;
	public int levelDemand = 50;

	void Awake(){
		instance = this;
	} 

	public void AddPermit(Permit permit){//called whenever a new permit is bought
		fishPools.AddRange(permit.myFishPools);
	}

	public void EvaluateProgress(){
		int permitCount = fishPools.Count;
		int exterminatedCount = 0;

		FishPoolInfo[] info = new FishPoolInfo[permitCount];
		for (int i = 0; i < permitCount; i++) {
			bool _ext = false;
			info [i] = CreatePoolInfo (fishPools [i], out _ext);

			if (_ext) {
				exterminatedCount++;
			}
		}

		bool playerCanContinue = false;
		string dockFeedback = "feedback";
		int maxValidExtCount = Mathf.FloorToInt ((float)permitCount / 2f);
		if (exterminatedCount > maxValidExtCount) {
			playerCanContinue = false;
			dockFeedback = "You exterminated more than half of the fishing population, of course we can't let you fish here. \n" +
			"You will destroy the entire population!";
		} else {
			int requiredCount = Mathf.FloorToInt ((float)levelDemand / 2f);
			if (scoreScript.SufficientFishCount(requiredCount)) {
				playerCanContinue = true;
				dockFeedback = "Okay, you've just got enough, you can continue if you want";
			} else {
				playerCanContinue = false;
				dockFeedback = "What?! You didn't even reach half our demand! \n" +
				"You cannot continue like this!";
			}
		}

		canvasScript.ShowResults (info, dockFeedback, playerCanContinue);
	}

	private FishPoolInfo CreatePoolInfo(FishPool fishPool, out bool exterminated){
		exterminated = false;
		FishPoolInfo poolInfo = new FishPoolInfo ();

		int remainedFish = fishPool.RemainingFishCount ();
		float fishPercentage = (float)remainedFish / fishPool.maxFishAmount;
		string fishPopulationHealt = "exterminated...";

		if (remainedFish < fishPool.minFishAmount) {
			exterminated = true;			
		}
		else if (fishPercentage > 0f && fishPercentage <= 0.33333f) {
			fishPopulationHealt = "endangered";
		}
		else if (fishPercentage > 0.333f && fishPercentage < 0.66666f) {
			fishPopulationHealt = "stable";
		}
		else if (fishPercentage >= 0.66666f) {
			fishPopulationHealt = "healthy";
		}

		fishPercentage *= 100f;
		poolInfo.speciesText = fishPool.fishName;
		poolInfo.infoText = fishPercentage + "% of this population survived";
		poolInfo.resultText = "Fish population health: " + fishPopulationHealt;

		return poolInfo;
	}
}

public class FishPoolInfo{
	public string speciesText;
	public string infoText;
	public string resultText;
}

[System.Serializable]
public class LevelDemand {
	
}
