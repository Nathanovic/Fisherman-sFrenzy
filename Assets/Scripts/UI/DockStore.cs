using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

//handles the UI, and the button-events for the dock
public class DockStore : MonoBehaviour {

	private UpgradeableStat selectedUpgradeable;

	[Header("Components:")]
	[SerializeField]private CanvasGroup tradePanel; 
	[SerializeField]private PlayerEconomics ecoScript;
	[SerializeField]private ShipInteractions interactionScript;
	[SerializeField]private Button buyButton;
	[Header("Selected Info Panel:")]
	[SerializeField]private RectTransform infoPanelTransform;
	[SerializeField]private Text upgradeTitleText;
	[SerializeField]private Text costText;
	[SerializeField]private Text resultText;
	[SerializeField]private Text currentStatText;
	[SerializeField]private Text maxUpgradedText;

	private void Start () {	
		interactionScript.onDockEntered += EnterDock;
		tradePanel.Deactivate ();
		buyButton.enabled = false;
	}

	private void EnterDock () {
		tradePanel.Activate ();
		GameManager.instance.DisableBoatControls ();
	}

	public void TryUpgradeStat(){
		bool succes = false;
		ecoScript.TryUpgrade (selectedUpgradeable.CurrentUpgrade (), out succes);

		if (succes) {
			selectedUpgradeable.DoUpgrade ();
			UpdateUpgradeInfo (selectedUpgradeable);
		}
	}

	public void LeaveDock(){//Button Event
		tradePanel.Deactivate ();
		GameManager.instance.EnableBoatControls ();
	}

	public void UpdateUpgradeInfo(UpgradeableStat upgradeScript){
		infoPanelTransform.SetParent (upgradeScript.transform);
		infoPanelTransform.anchoredPosition = Vector2.zero;

		selectedUpgradeable = upgradeScript;
		upgradeTitleText.text = upgradeScript.UpgradeTitle ();
		currentStatText.text = "Current: " + upgradeScript.CurrentUpgradeName ();

		if (upgradeScript.CanPurchaseUpgrade ()) {
			buyButton.enabled = true;
			maxUpgradedText.enabled = false;
			Upgrade selectedUpgrade = upgradeScript.CurrentUpgrade();

			costText.text = "This upgrade costs " + selectedUpgrade.fishCost + " KG fish";
			resultText.text = selectedUpgrade.BenefitText ();
		}
		else {
			buyButton.enabled = false;
			maxUpgradedText.enabled = true;
		}
	}
} 