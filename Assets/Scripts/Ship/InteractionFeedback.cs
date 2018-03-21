using UnityEngine;

public class InteractionFeedback : MonoBehaviour {

	[SerializeField]private ShipController shipScript;

	[SerializeField]private AudioClip bounceSound;
	[SerializeField]private AudioClip shipChafeSound;

	void Start(){
		shipScript.onBounceOff += ShipBounced;
	}

	void ShipBounced(float bounceFactor){//value between 0 and 1
		if (bounceFactor == 0)
			AudioManager.instance.PlaySFX (shipChafeSound);
		else
			AudioManager.instance.PlaySFX (bounceSound, bounceFactor);
	}
}
