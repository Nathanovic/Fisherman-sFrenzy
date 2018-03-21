using UnityEngine;
using UnityEngine.UI;

//this script is used to activate, walk through and finish the tutorial
public class Tutorial : MonoBehaviour {

	public CanvasGroup panel;

	public Image[] tutorialImages;
	private int tutorialCurrent = 0;
	public int tutorialViewCount = 3;

	void Awake(){
		panel = GetComponent<CanvasGroup> ();
	}

	void Start(){
		Debug.Log ("build version: " + Application.version);
		tutorialImages = GetComponentsInChildren<Image> ();
	}

	public void Continue(){
		tutorialCurrent++;
		if (tutorialCurrent == tutorialViewCount) {
			panel.Deactivate ();
		}
	}
}
