using System.Collections.Generic;
using UnityEngine;
using FishFSM;

public class Fish : MonoBehaviour {

	private FiniteStateMachine fsm;

	private FishModel myData;

	private FishPool myPool {
		get {
			return myData.myPool;
		}
	}
	private FishConfig conf;

	private Vector3 acceleration;
	public Vector3 position{
		get{
			return myData.position;
		}
		set{ 
			myData.position = value;
		}
	}
	public Vector3 velocity;

	public float speedFactor;

	private Vector3 wanderTarget;

	public string myStateQQQ;

	public FishIndicator minimapIndicator;

	public void Init(FishPool pool, FishConfig config){
		conf = config;
		myData = GetComponent<FishModel> ();
		myData.conf = conf;
		myData.Init (pool);
		fsm = new FiniteStateMachine (this, myData);

		position = transform.position;
		velocity = new Vector3(RandomVal(0.1f), RandomVal(0.05f), RandomVal(0.1f));

		Transform minimap = Sonar.instance.GetMinimapTransform ();
		minimapIndicator = GameObject.Instantiate (minimapIndicator, minimapIndicator.transform.position, Quaternion.identity, minimap) as FishIndicator;
		minimapIndicator.Init (myData);
	}

	void Update(){
		fsm.RunState ();

		Vector3 combineVec = fsm.currentState.GetCombinedVector ();
		acceleration += combineVec;
		acceleration = Vector3.ClampMagnitude (acceleration, conf.maxAcceleration);
		velocity += acceleration * Time.deltaTime;
		velocity = Vector3.ClampMagnitude (velocity, conf.maxVelocity);
		position += velocity * Time.deltaTime;
		transform.position = position;

		if (combineVec == Vector3.zero && velocity != Vector3.zero) {
			acceleration = Vector3.zero;
			velocity = Vector3.MoveTowards (velocity, Vector3.zero, conf.deceleration * Time.deltaTime);
		}else{
			transform.LookAt(transform.position + velocity);
		}

		myStateQQQ = fsm.currentState.ToString ();
	}

	public Vector3 Wander(){
		Vector3 wanderAccel = new Vector3 (RandomBinomial (), RandomBinomial (), RandomBinomial ());
		wanderTarget += wanderAccel * conf.wanderAcceleration * Time.deltaTime;
		wanderTarget = Vector3.ClampMagnitude (wanderTarget, conf.wanderDistance);

		return wanderTarget * conf.wanderPriority;
	}

	public Vector3 Separation(){
		Vector3 vec = new Vector3 ();

		List<Fish> neighbors = myPool.GetNeighbors (this, conf.separationRadius);
		if (neighbors.Count == 0) 
			return vec;

		foreach (Fish fish in neighbors) {
			Vector3 avoidDir = position - fish.position;
			vec += avoidDir.normalized / avoidDir.magnitude;
		}

		return vec.normalized * conf.separationPriority;
	}

	public Vector3 Cohesion(){
		Vector3 vec = new Vector3 ();

		List<Fish> neighbors = myPool.GetNeighbors (this, conf.cohesionRadius);
		if (neighbors.Count == 0) 
			return vec;

		foreach (Fish fish in neighbors) {
			if (OtherInFOV (fish.position)) {
				Vector3 dir = fish.position - position;
				vec += dir.normalized;
			}
		}

		return vec.normalized * conf.cohesionPriority;
	}

	public Vector3 Alignment(){
		Vector3 vec = new Vector3 ();

		List<Fish> neighbors = myPool.GetNeighbors (this, conf.alignmentRadius);
		if (neighbors.Count == 0) 
			return vec;

		foreach (Fish fish in neighbors) {
			if (OtherInFOV (fish.position)) {
				float priority = (fish.position - position).magnitude;
				vec += fish.velocity * priority;
			}
		}

		return vec.normalized * conf.alignmentPriority;
	}

	public Vector3 GoalSteering(){
		Vector3 vec = transform.parent.position - transform.position;
		Debug.DrawRay (transform.position, vec);
		return vec.normalized * conf.seekTargetPriority;
	}

	public Vector3 BoundsLimitation(){
		Vector3 vec = new Vector3 ();

		RaycastHit hit;
		if (Physics.Raycast (position, velocity, out hit, conf.checkBoundsRadius, conf.boundsLM)) {
			vec += hit.normal;
		}

		return vec.normalized * conf.boundsPriority;
	}

	float RandomVal(float r){
		return Random.Range(-r, r);
	}

	public void CaughtInNet(){
		Renderer[] visuals = GetComponentsInChildren<Renderer> ();
		for (int i = 0; i < visuals.Length; i++) {
			visuals [i].enabled = false;
		}

		myPool.FishCaught (this);
	}

	//make sure we swim again to the center of a fishpool
	public void EscapeFromNet(){
		Vector3 newPos = myData.net.position + Random.insideUnitSphere;
		newPos.y = Random.Range (-conf.checkBoundsRadius * 2, -conf.checkBoundsRadius);
		transform.position = position = newPos;

		Renderer[] visuals = GetComponentsInChildren<Renderer> ();
		for (int i = 0; i < visuals.Length; i++) {
			visuals [i].enabled = true;
		}	

		myPool.FishEscaped (this);
	}

	public bool OtherInFOV(Vector3 otherPos){
		return Vector3.Angle (velocity, otherPos - position) <= conf.vof;
	}

	public float RandomBinomial(){
		return Random.Range (0f, 1f) - Random.Range (0f, 1f);
	}
}
