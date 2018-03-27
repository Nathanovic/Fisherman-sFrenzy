using UnityEngine.UI;
using UnityEngine;

public class ScoreValueText : MonoBehaviour {

	public PlayerEconomics playerEcoScript;
	private Text myText;

	void Start () {
		myText = GetComponent<Text> ();

		playerEcoScript.totalValueHolder.onValueChanged += ScoreValueChanged;
		int fishValue = playerEcoScript.fishValueHolder.GetValue ();
		ScoreValueChanged (fishValue);
	}

	void ScoreValueChanged(int newValue){
		myText.text = "Score: " + newValue.ToString ();
	}
}
