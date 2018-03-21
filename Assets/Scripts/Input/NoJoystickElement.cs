using UnityEngine;

//dit script vraagt aan joystickscript: zorg maar dat er niet op mij een joystick kan verschijnen!
public class NoJoystickElement : MonoBehaviour {

	void Start () {
		RectTransform rt = GetComponent<RectTransform> ();
		ShipInputManager.instance.AddNotClickable (rt);
	}
}
