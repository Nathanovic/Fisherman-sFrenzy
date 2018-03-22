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
		yield return StartCoroutine(FadeVignette (0f, maxA, fadeTime)); 
		yield return new WaitForSeconds (stayInTime);
		yield return StartCoroutine(FadeVignette (maxA, 0f, fadeTime)); 
	}

	IEnumerator FadeVignette(float startA, float endA, float duration){
		float t = 0f;
		Color c = vignetteMat.GetColor(colorProperty);
		c.a = startA;
		vignetteMat.color = c;
		while (t < 1f) {
			t += Time.deltaTime / duration;
			c.a = Mathf.Lerp (startA, endA, t);
			vignetteMat.SetColor(colorProperty, c);
			yield return null;
		}
	}
}
