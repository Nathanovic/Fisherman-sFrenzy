using UnityEngine;

public class FishConfig : MonoBehaviour {

	public float maxAcceleration;
	public float maxVelocity;
	public float deceleration;
	public float vof = 100f; 

	public float wanderAcceleration;
	public float wanderDistance;
	public float wanderPriority;

	public float separationRadius;
	public float separationPriority;

	public float cohesionRadius;
	public float cohesionPriority;

	public float alignmentRadius;
	public float alignmentPriority;

	public float seekTargetPriority;

	public LayerMask boundsLM;
	public float checkBoundsRadius;
	public float boundsPriority;
}
