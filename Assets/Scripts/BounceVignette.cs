using UnityEngine;
using System.Collections;

public class BounceVignette : MonoBehaviour {

	public Material vignetteMat;
	public float maxAlpha;
	public float fadeTime = 0.25f;
	public float bounceMagnitudeMultiplier = 0.1f;
	public ShipInteractions interactionScript;

	void Start () {
		interactionScript.onHitObstacle += ShowVignette;
	}
	
	void ShowVignette(Vector3 bounceVector){			
		StartCoroutine (FadeVignette (bounceVector.magnitude));
	}

	IEnumerator FadeVignette(float magn){
		float maxA = Mathf.Min (maxAlpha, maxAlpha * magn * bounceMagnitudeMultiplier);
		yield return StartCoroutine(FadeVignette (0f, maxA, fadeTime)); 
		yield return StartCoroutine(FadeVignette (maxA, 0f, fadeTime)); 
	}

	IEnumerator FadeVignette(float startA, float endA, float duration){
		float t = 0f;
		Color c = vignetteMat.GetColor("_TintColor");
		c.a = startA;
		vignetteMat.color = c;
		while (t < 1f) {
			t += Time.deltaTime / duration;
			c.a = Mathf.Lerp (startA, endA, t);
			vignetteMat.SetColor("_TintColor", c);
			yield return null;
		}
	}
}
