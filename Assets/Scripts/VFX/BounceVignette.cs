using UnityEngine;

public class BounceVignette : VignetteVFX {

	public ShipInteractions interactionScript;

	void Start () {
		interactionScript.onHitObstacle += ShowVignette;
	}

	void ShowVignette(Vector3 bounceVector){			
		StartCoroutine (FadeVignette (bounceVector.magnitude));
	}
}
