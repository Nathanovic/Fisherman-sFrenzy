using UnityEngine;
using System.Collections;

public class VignetteVFX : MonoBehaviour {

	public string colorProperty = "_TintColor";
	public Material vignetteMat;
	public float maxAlpha;
	public float fadeTime = 0.25f;
	public float stayInTime = 0f;
	public float valueMultiplier = 1f;

	//this IENumerator is called by derived classes to start fading
	protected IEnumerator FadeVignette(float fadeStrength){
		float maxA = Mathf.Min (maxAlpha, maxAlpha * fadeStrength * valueMultiplier);
		yield return StartCoroutine(FadeVignette (0f, maxA)); 
		yield return new WaitForSeconds (stayInTime);
		yield return StartCoroutine(FadeVignette (maxA, 0f)); 
	}

	protected IEnumerator FadeVignette(float startA, float endA){
		float t = 0f;
		Color c = vignetteMat.GetColor(colorProperty);
		c.a = startA;
		while (t < 1f) {
			t += Time.deltaTime / fadeTime;
			c.a = Mathf.Lerp (startA, endA, t);
			vignetteMat.SetColor(colorProperty, c);
			yield return null;
		}
	}
}
