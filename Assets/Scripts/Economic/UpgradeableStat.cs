using UnityEngine;
using UnityEngine.UI;

//this is used for a upgrade-panel:
//manages which upgrade of type 'stat' can still be done
public class UpgradeableStat : MonoBehaviour {

	[SerializeField]private string defaultUpgradeName = "default";
	private int currentUpgrade = 0;//QQQ
	public ShipUpgradeable stat;
	[SerializeField]private Upgrade[] upgrades;

	private Text descriptionText;

	private void Start () {
		for (int i = 0; i < upgrades.Length; i++) {
			upgrades [i].stat = stat;
		}
	}

	public Upgrade CurrentUpgrade(){
		return upgrades [currentUpgrade];
	}

	public void DoUpgrade(){
		currentUpgrade++;
	}

	//used to show the player whether he has already fully upgraded something
	public bool CanPurchaseUpgrade(){
		if (currentUpgrade == upgrades.Length) {
			return false;
		}
		else {
			return true;
		}
	}

	public string UpgradeTitle(){
		if (CanPurchaseUpgrade ()) {
			return CurrentUpgrade ().upgradeTitle;
		}
		else {
			return "Upgrade " + stat.ToString ();
		}
	}

	public string CurrentUpgradeName(){
		int currentUpgradeIndex = currentUpgrade - 1;
		return currentUpgradeIndex > -1 ? upgrades [currentUpgradeIndex].upgradeTitle : defaultUpgradeName;
	}
}

[System.Serializable]
public class Upgrade {
	public string upgradeTitle = "Upgrade xxxx";
	[HideInInspector]public ShipUpgradeable stat;
	public int fishCost = 1;
	public int upgradeValue;
	public Permit linkedPermit;//slordig dat deze met alle ShipUpgradeables zichtbaar is

	public string BenefitText(){
		return "This upgrade will grant you " + upgradeValue.ToString () + " extra " + stat.ToString () + "!"; 
	}
}
