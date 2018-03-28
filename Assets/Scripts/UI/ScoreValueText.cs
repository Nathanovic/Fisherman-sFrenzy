using UnityEngine.UI;
using UnityEngine;

public class ScoreValueText : MonoBehaviour {

	public PlayerEconomics playerEcoScript;
	private Text myText;

	void Start () {
		myText = GetComponent<Text> ();

		playerEcoScript.totalValueHolder.onValueChanged += ScoreValueChanged;
		int fishValue = playerEcoScript.totalValueHolder.GetValue ();
		ScoreValueChanged (fishValue);
	}

	void ScoreValueChanged(int newValue){
		myText.text = newValue.ToString () + "/" + ProgressionManager.instance.seasonDemandAmount.ToString();
	}
}
