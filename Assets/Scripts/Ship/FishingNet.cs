using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class FishingNet : MonoBehaviour {

	private Collider myColl;
	private Renderer myRenderer;
	private ShipStats shipStats;

	private PlayerEconomics ecoScript;

	public List<FishModel> fishesInNet = new List<FishModel> ();

	[SerializeField]private Image fillRect;

	public FishNetState myState = FishNetState.netUp;

	public event DefaultDelegate onFishCaught;
	public event DefaultDelegate onNetDown;
	public event DefaultDelegate onNetBroken;
	public delegate void NetUpEvent(int fishCount);
	public event NetUpEvent onNetUp;

	private bool canHandleNet = true;

	private Counter catchFishCounter;
	public float maxCatchFishInterval = 0.5f;
	private bool canCatchFish = true;

	//shipStats implementation:
	private int maxFishCount{
		get{
			return shipStats.netSize;
		}
	}

	void Start(){
		shipStats = transform.parent.GetComponent<ShipStats> ();
		ecoScript = transform.parent.GetComponent<PlayerEconomics> ();
		myColl = GetComponent<Collider> ();
		myRenderer = GetComponent<Renderer> ();
		fillRect.fillAmount = 0f;
		Deactivate ();

		//set up the system that is needed to prevent the net from getting full in a very short time
		catchFishCounter = new Counter (maxCatchFishInterval);
		catchFishCounter.onCount += EnableCatchingFish;

		//make sure we can only use the net if the game manager allows us to:
		GameManager.instance.onBoatControlsDisabled += BoatControlsDisabled;
		GameManager.instance.onBoatControlsEnabled += BoatControlsEnabled;
	}

	void Update(){
		if (!canHandleNet)
			return;

		if (ShipInputManager.instance.doubleTapped) {
			ToggleNet ();
		}
	}

	public void ToggleNet(){
		if(myState == FishNetState.netUp)
			ThrowOutNet ();
		else if(myState == FishNetState.netDown)// || myState == FishNetState.netBroken)
			PullUpNet ();		
	}

	void ThrowOutNet(){
		myState = FishNetState.netDown;
		myColl.enabled = true;
		myRenderer.enabled = true;

		if (onNetDown != null) {
			onNetDown ();
		}
	}

	void Deactivate(){
		myColl.enabled = false;
		myRenderer.enabled = false;		
	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "Fish" && canCatchFish) {
			TryPutFishInNet (other.gameObject);
		}
	}

	void TryPutFishInNet(GameObject fishObject){
		if (myState != FishNetState.netDown)
			return;
		
		if (fishesInNet.Count == maxFishCount) {
			foreach (FishModel fish in fishesInNet) {
				fish.Escape ();
			}

			fillRect.fillAmount = 0f;
			fishesInNet.Clear ();

			if (onNetBroken != null) {
				onNetBroken ();
			}

			PullUpNet ();
		} else {
			FishModel fish = fishObject.GetComponent<FishModel> ();
			fishesInNet.Add (fish);
			fish.CatchMe (transform);

			if (onFishCaught != null) {
				onFishCaught ();
			}
		}

		fillRect.fillAmount = (float)fishesInNet.Count / maxFishCount;

		OnFishCaught ();
	}

	void PullUpNet(){
		//GameManager.instance.GameFeedback ("You pull up your net...");
		//myState = FishNetState.pullingNet;

		//yield return new WaitForSeconds (4f);

		Deactivate ();
		fillRect.fillAmount = 0f;

		int fishCount = fishesInNet.Count;
		int limitedFishCount = ecoScript.LimitedStorageFishCount (fishCount);

		for (int i = 0; i < limitedFishCount; i++) {
			fishesInNet [i].Kill ();
		}
		for (int i = limitedFishCount; i < fishCount; i++) {
			Debug.Log ("fish: " + i + " escaped");
			fishesInNet [i].Escape ();
		}

		fishesInNet.Clear ();	
		myState = FishNetState.netUp;

		if (onNetUp != null) {
			onNetUp (limitedFishCount);
		}
	}

	//make sure we can't catch 10 fishes in 0.001 second:
	private void OnFishCaught(){
		canCatchFish = false;
		catchFishCounter.StartCounter ();
	}

	private void EnableCatchingFish(){
		canCatchFish = true;
	}

	private void BoatControlsDisabled(){
		canHandleNet = false;
	}

	private void BoatControlsEnabled(){
		canHandleNet = true;
	}
}

[System.Serializable]
public enum FishNetState{
	netDown,
	//pullingNet,
	netUp//,
	//netBroken
}