using UnityEngine;
using UnityEngine.UI;

//used to display how much fish we have
public class FishValueText : MonoBehaviour {

	private ShipStats statScript;
	public PlayerEconomics playerEcoScript;
	private Text myText;
	private Color defaultColor;
	public Color warningColor;

	void Start () {
		myText = GetComponent<Text> ();
		statScript = playerEcoScript.GetComponent<ShipStats> ();

		defaultColor = myText.color;

		playerEcoScript.fishValueHolder.onValueChanged += FishValueChanged;
		int fishValue = playerEcoScript.fishValueHolder.GetValue ();
		FishValueChanged (fishValue);
	}

	void FishValueChanged(int newValue){
		myText.text = newValue.ToString () + " KG";
		if (warningColor != Color.clear) {
			if (newValue >= statScript.storageSize) {
				myText.color = warningColor;
			}
			else {
				myText.color = defaultColor;
			}
		}
	}
}
