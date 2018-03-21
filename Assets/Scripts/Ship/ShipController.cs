using UnityEngine;

public class ShipController : MonoBehaviour {

	private ShipStats stats;
	private Rigidbody rb;
	private Transform visual;
	private Vector3 visualDefaultEuler;

	private float speedFactor = 1f;//[0 - 1]
	[Range(0f, 1f)]public float netSpeedFactor = 0.6f;
	private float currentSpeed;
	public float backwardsSpeedFactor;
	public float accSpeed;
	[Range(0f,7f)]public float speedDegenTime = 4f;

	private float currentRotateSpeed;
	public float accRotation;
	[Range(0f,3f)]public float rotDegenTime = 1f;

	[Range(0f,1f)]public float rotSpeedRelation = 0.5f;

	[Header("Bounce values:")]
	public float velocityThreshold = 1f;
	public float bounceMultiplier = 1f;
	private float remainingStunDuration = 0f;
	public float stunMultiplier = 1f;
	public float maxStunDuration = 2f;
	public float minBounceMagnitude = 3f;
	public float maxBounceMagnitude = 10f;

	//stats implementation:
	private float maxForwardSpeed {
		get { 
			return stats.sailSpeed;	
		}
	}
	private float maxRotationSpeed {
		get { 
			return stats.rotationSpeed;	
		}
	}

	private void Start(){
		stats = GetComponent<ShipStats> ();
		rb = GetComponent<Rigidbody> ();
		visual = transform.GetChild (0);
		visualDefaultEuler = visual.rotation.eulerAngles;

		FishingNet netScript = GetComponentInChildren<FishingNet> ();
		netScript.onNetDown += NetDown;
		netScript.onNetUp += NetUp;

		ShipInteractions interactionScript = GetComponent<ShipInteractions> ();
		interactionScript.onHitObstacle += BounceOff;
	}

	public float _vertical;
	public float _horizontal;
	private void FixedUpdate(){
		if (remainingStunDuration > 0f) {
			remainingStunDuration -= Time.fixedDeltaTime;
			return;
		}

		//get input:
		Vector3 moveAssignment = ShipInputManager.instance.movement;
		float horizontal = _horizontal = ShipInputManager.instance.horizontalInput;
		float vertical = _vertical = moveAssignment.z;

		//set rotate speed:
		/* rotation speed with rotate-acceleration:
		if(horizontal != 0){
			currentRotateSpeed += horizontal * accRotation;
			float maxRotSpeed = 0.5f * maxRotationSpeed + maxRotationSpeed * (currentSpeed / (maxForwardSpeed * 2));
			currentRotateSpeed = Mathf.Clamp (currentRotateSpeed, -maxRotSpeed, maxRotSpeed);
		}
		if(Mathf.Abs(horizontal) < 0.15f){
			currentRotateSpeed = ResetValueOverTime (currentRotateSpeed, maxRotationSpeed, rotDegenTime);
		}
		*/
		currentRotateSpeed = maxRotationSpeed * horizontal;

		//rotate:
		Vector3 myEuler = rb.rotation.eulerAngles;
		float myRotation = currentRotateSpeed * rotSpeedRelation * currentSpeed;
		myEuler.y += myRotation;
		rb.MoveRotation (Quaternion.Euler (myEuler));

		//rotate visual:
		visual.transform.localEulerAngles = visualDefaultEuler + new Vector3 (currentSpeed * 0.4f, 0f, 0f);

		//set movement speed:
		float maxSpeed = maxForwardSpeed * speedFactor * Mathf.Abs(vertical);
		if (currentSpeed <= maxSpeed && vertical != 0f) {
			float acceleration = vertical * accSpeed;
			currentSpeed += acceleration;
			currentSpeed = Mathf.Clamp (currentSpeed, -maxSpeed, maxSpeed);
		}
		else {
			currentSpeed = ResetValueOverTime (currentSpeed, maxForwardSpeed, speedDegenTime);
		}

		//move:
		rb.velocity = transform.forward * currentSpeed;
	}

	float ResetValueOverTime(float currentValue, float maxValue, float degenTime){
		if (currentValue == 0f)
			return 0f;
		
		float positive = (currentValue > 0f) ? 1f : -1f;
		float t = 1f - (Mathf.Abs(currentValue) / maxValue) + Time.fixedDeltaTime * (1f/degenTime);
		return Mathf.Lerp (maxValue, 0f, t) * positive;
	}

	void NetDown(){//decrease speed
		speedFactor = netSpeedFactor;
	}

	void NetUp(int fishCount){//increase speed
		speedFactor = 1f;
	}

	void BounceOff(Vector3 bounceDir){
		float magnitudeMultiplier = bounceDir.magnitude;
		if (magnitudeMultiplier < velocityThreshold)
			return;

		remainingStunDuration = Mathf.Min (stunMultiplier * magnitudeMultiplier, maxStunDuration);;
		Vector3 bounceVel = bounceDir.normalized * bounceMultiplier * magnitudeMultiplier;
		float bounceMagnitude = Mathf.Clamp (bounceVel.magnitude, minBounceMagnitude, maxBounceMagnitude);
		rb.velocity = bounceVel.normalized * bounceMagnitude;

		currentSpeed = 0f;
		currentRotateSpeed = 0f;
	}
}
