using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

//handles the UI, and the button-events for the dock
public class DockStore : MonoBehaviour {

	private UpgradeableStat selectedUpgradeable;
	public event DefaultDelegate onDockLeft;

	[Header("Components:")]
	[SerializeField]private Permit selectedPermit;
	[SerializeField]private Text permitTitle;
	[SerializeField]private Text permitDescription;
	[SerializeField]private Button buyPermitButton;

	[SerializeField]private CanvasGroup tradePanel; 
	[SerializeField]private CanvasGroup upgradePanel; 
	[SerializeField]private CanvasGroup permitPanel; 
	[SerializeField]private PlayerEconomics ecoScript;
	[SerializeField]private ShipController ship;
	[SerializeField]private ShipInteractions interactionScript;
	[SerializeField]private Button buyButton;
	[Header("Selected Info Panel:")]
	[SerializeField]private RectTransform infoPanelTransform;
	[SerializeField]private Text upgradeTitleText;
	[SerializeField]private Text costText;
	[SerializeField]private Text resultText;
	[SerializeField]private Text currentStatText;
	[SerializeField]private Text maxUpgradedText;

	[Header("Dock origin:")]
	[SerializeField]private Transform dockOrigin;

	public DefaultDelegate onPermitBought;

	private void Start () {	
		interactionScript.onDockEntered += EnterDock;

		UpdateSelectedPermitInfo (selectedPermit);
		GoToUpgradePanel ();
		tradePanel.Deactivate ();
	}

	//can be called from the gamemanager
	public void EnterDock () {
		ship.EnterPort (dockOrigin);
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

		if (onDockLeft != null) {
			onDockLeft ();
		}
	}

	public void UpdateUpgradeInfo(UpgradeableStat upgradeScript){
		infoPanelTransform.SetParent (upgradeScript.transform);
		infoPanelTransform.anchoredPosition = Vector2.zero;

		selectedUpgradeable = upgradeScript;
		upgradeTitleText.text = upgradeScript.UpgradeTitle ();
		currentStatText.text = "Current: " + upgradeScript.CurrentUpgradeName ();

		if (upgradeScript.CanPurchaseUpgrade ()) {
			buyButton.interactable = true;
			maxUpgradedText.enabled = false;
			Upgrade selectedUpgrade = upgradeScript.CurrentUpgrade();

			costText.text = "This upgrade costs " + selectedUpgrade.fishCost + " KG fish";
			resultText.text = selectedUpgrade.BenefitText ();
		}
		else {
			buyButton.interactable = false;
			maxUpgradedText.enabled = true;
		}
	}

	//select a permit: show it's info and enable buying, if possible
	public void UpdateSelectedPermitInfo(Permit permit){
		permitTitle.text = permit.name;
		if (permit.unlocked) {
			permitDescription.text = "You already have access to this permit!";
			buyPermitButton.interactable = false;
		}
		else if (!permit.CanBuyPermit ()) {
			permitDescription.text = "You can't buy this permit yet";
			buyPermitButton.interactable = false;
		}
		else {
			permitDescription.text = "This permit will cost you " + permit.cost + " KG fish";
			buyPermitButton.interactable = true;
		}

		selectedPermit = permit;
	}

	//the player clicked the buy-permit button
	public void TryBuySelectedPermit(){
		bool succes = false;
		ecoScript.TryBuyPermit (selectedPermit, out succes);
		if (succes) {
			onPermitBought ();
			permitDescription.text = "You now have access to this permit!";
			buyPermitButton.interactable = false;
		}
	}

	public void GoToPermitPanel(){
		upgradePanel.Deactivate ();
		permitPanel.Activate ();
	}

	public void GoToUpgradePanel(){
		upgradePanel.Activate ();
		permitPanel.Deactivate ();
	}
} 