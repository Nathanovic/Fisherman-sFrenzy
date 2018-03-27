using UnityEngine;
using UnityEngine.UI;

public class FishPoolDisplayer : MonoBehaviour {

	private CanvasGroup cvg;
	private Text fishPermitText;
	private Text fishInfoText;
	private Text fishResultText;

	void Start () {
		cvg = GetComponent<CanvasGroup> ();
		cvg.Deactivate ();
		fishPermitText = transform.GetChild (0).GetComponent<Text> ();
		fishInfoText = transform.GetChild (1).GetComponent<Text> ();
		fishResultText = transform.GetChild (2).GetComponent<Text> ();
	}

	public void Activate(FishPoolInfo info){
		cvg.Activate ();

		fishPermitText.text = info.poolText;
		fishInfoText.text = info.infoText;
		fishResultText.text = info.resultText;
	}

	public void Deactivate(){
		cvg.Deactivate ();
	}
}
