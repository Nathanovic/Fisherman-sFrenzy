using UnityEngine.UI;
using UnityEngine;

//this script shows the fishHealth info to the player
//thiss is done by subscribing functionality to the ShipInteractions events
public class FishHealthInfo : MonoBehaviour {

	private Transform camTransform;
	private CanvasCounter canvasCounter;
	private Image image;
	public ShipInteractions interactionScript;

	private FishPool poolScript;//-> the fishpool we want to display the health from
	private Transform target;
	public float yOffset = 3f;

	[Range(0f,1f)]public float dangerHealthPercentage = 0.5f;
	public Color dangerHealthColor;
	public Color noRepopHealthColor;
	public Color exterminatedHealthColor;

	void Start () {
		camTransform = Camera.main.transform;
		image = GetComponent<Image> ();

		interactionScript.onFishPoolEntered += EnableSelf;
		interactionScript.onFishPoolLeft += DisableSelf;

		CanvasGroup cvg = GetComponent<CanvasGroup> ();
		canvasCounter = new CanvasCounter (cvg, 0.5f, 0.5f, 1f);
		canvasCounter.onCount += canvasCounter.StopCounter;
		cvg.Deactivate ();
	}

	void Update () {
		if (target == null)
			return;
		
		Vector3 targetPos = target.position + Vector3.up * yOffset;
		transform.position = targetPos;

		Vector3 lookDir = transform.position - camTransform.position;
		lookDir.y = 0f;
		transform.rotation = Quaternion.LookRotation (lookDir);

		SetHealthColor ();
	}

	void EnableSelf(FishPool pool){
		target = pool.transform;
		poolScript = pool;

		SetHealthColor ();
		canvasCounter.SetTargetA (1f);
		canvasCounter.StartCounter ();
	}

	void DisableSelf(FishPool pool){
		canvasCounter.SetTargetA (0f);
		canvasCounter.StartCounter ();
	}

	void SetHealthColor(){
		Color healthColor = Color.green;
		int fishCount = poolScript.RemainingFishCount ();
		float healthPercent = (float)fishCount / poolScript.maxFishAmount;
		if (healthPercent < dangerHealthPercentage && fishCount >= poolScript.minFishAmount)
			healthColor = dangerHealthColor;
		else if (fishCount < poolScript.minFishAmount && fishCount > 0)
			healthColor = noRepopHealthColor;
		else if (fishCount == 0)
			healthColor = exterminatedHealthColor;		

		image.color = healthColor;
	}
}
