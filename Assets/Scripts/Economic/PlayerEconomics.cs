using UnityEngine;
using UnityEngine.UI;

public class PlayerEconomics : MonoBehaviour {

	private ShipStats statScript;
	public IntValueHolder fishValueHolder;

	void Awake(){
		fishValueHolder = new IntValueHolder ();		
	}

	void Start(){
		statScript = GetComponent<ShipStats> ();
		FishingNet fishingScript = GetComponentInChildren<FishingNet> ();

		fishingScript.onNetUp += AddFish;
	}

	void Update(){
		if (Input.GetKeyUp (KeyCode.RightBracket)) {
			AddFish (10);
		}
	}

	private void AddFish(int count){
		fishValueHolder.AddValue(count);
	}

	public void TryUpgrade(Upgrade upgrade, out bool succes){
		int upgradeCost = upgrade.fishCost;

		if (SufficientFishCount (upgradeCost)) {
			UseFishForUpgrade (upgradeCost);
			Debug.Log ("try buy: " + upgrade.stat.ToString ());
			if (upgrade.stat != ShipUpgradeable.permit) {
				statScript.UpgradeStat (upgrade);
			}
			else {
				BuyPermit (upgrade.linkedPermit);
			}

			succes = true;
		}
		else {
			succes = false;
		}
	}

	private void BuyPermit(Permit permit){
		Debug.Log ("buy permit! " + permit.name);
		permit.Unlock ();
		ProgressionManager.instance.AddPermit (permit);
	}

	void UseFishForUpgrade(int fish){
		fishValueHolder.AddValue (-fish);
	}

	public bool SufficientFishCount(int requiredCount){
		return fishValueHolder.GetValue() >= requiredCount;
	}

	public class IntValueHolder{

		private int myValue = 0;
		public delegate void ValueChangedDelegate (int newValue);
		public event ValueChangedDelegate onValueChanged;

		public int GetValue(){
			return myValue;
		}

		public void AddValue(int addValue){
			myValue += addValue;
			if (onValueChanged != null) {
				onValueChanged (myValue);
			}
		}
	}
}