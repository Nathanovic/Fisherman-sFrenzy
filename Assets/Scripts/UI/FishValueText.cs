using UnityEngine;
using UnityEngine.UI;

//used to display how much fish we have
public class FishValueText : MonoBehaviour {

	public PlayerEconomics playerEcoScript;
	private Text myText;

	void Start () {
		myText = GetComponent<Text> ();

		playerEcoScript.fishValueHolder.onValueChanged += FishValueChanged;
		int fishValue = playerEcoScript.fishValueHolder.GetValue ();
		FishValueChanged (fishValue);
	}

	void FishValueChanged(int newValue){
		myText.text = newValue.ToString () + " KG";
	}
}
