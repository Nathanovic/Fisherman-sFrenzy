using UnityEngine;
using UnityEngine.UI;

public class PlayerEconomics : MonoBehaviour {

	private ShipStats statScript;
	public IntValueHolder totalValueHolder;
	public IntValueHolder fishValueHolder;
	public Image storageFill;
	public Text storageText;
	private Color defaultColor;
	public Color warningColor;

	void Awake(){
		totalValueHolder = new IntValueHolder ();
		fishValueHolder = new IntValueHolder ();		
	}

	void Start(){
		statScript = GetComponent<ShipStats> ();
		FishingNet fishingScript = GetComponentInChildren<FishingNet> ();

		fishingScript.onNetUp += AddFish;
		defaultColor = storageText.color;
		UpdateStorageFillness ();
	}

	void Update(){
		if (Input.GetKeyUp (KeyCode.RightBracket)) {
			AddFish (10);
		}
	}

	public int LimitedStorageFishCount(int count){
		int fullStorageDiff = statScript.storageSize - fishValueHolder.GetValue ();
		return Mathf.Min (count, fullStorageDiff);
	}

	private void AddFish(int count){
		totalValueHolder.AddValue (count);
		fishValueHolder.AddValue(count);
		UpdateStorageFillness ();
	}

	public void TryUpgrade(Upgrade upgrade, out bool succes){
		int upgradeCost = upgrade.fishCost;

		if (SufficientFishCount (upgradeCost)) {
			UseFishForUpgrade (upgradeCost);
			Debug.Log ("try buy: " + upgrade.stat.ToString ());
			if (upgrade.stat != ShipUpgradeable.permit) {
				statScript.UpgradeStat (upgrade);
			}

			succes = true;
		}
		else {
			succes = false;
		}
	}

	public void TryBuyPermit(Permit permit, out bool succes){
		if (SufficientFishCount (permit.cost)) {
			UseFishForUpgrade (permit.cost);
			BuyPermit (permit);
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
		UpdateStorageFillness ();
	}

	public bool SufficientFishCount(int requiredCount){
		return fishValueHolder.GetValue() >= requiredCount;
	}

	public bool SufficientScoreCount(int requiredCount){
		return totalValueHolder.GetValue () >= requiredCount;
	}

	void UpdateStorageFillness(){
		float fillAmount = fishValueHolder.GetValue () / statScript.storageSize;
		storageFill.fillAmount = fillAmount;
		storageText.color = fillAmount == 1f ? warningColor : defaultColor;
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