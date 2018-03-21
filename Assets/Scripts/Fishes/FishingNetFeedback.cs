using System.Collections;
using UnityEngine;

public class FishingNetFeedback : MonoBehaviour {

	[SerializeField]private FishingNet fishNetScript;

	private ParticleSystem fishUpPS;
	private ParticleSystem.MainModule psMain;
	private float fishBubbleTime;

	[SerializeField]private AudioClip netDownSound;
	[SerializeField]private AudioClip netBrokenSound;
	[SerializeField]private AudioClip fishUpSound;
	[SerializeField]private float fishUpSoundDelay = 1.5f;

	void Start () { 
		fishUpPS = GetComponent<ParticleSystem> ();
		psMain = fishUpPS.main;
		float psRateOverTime = fishUpPS.emission.rateOverTimeMultiplier;
		fishBubbleTime = 1f / psRateOverTime;

		fishNetScript.onNetUp += FishUpFeedback;
		fishNetScript.onNetBroken += NetBrokenFeedback;
	}

	void NetDownFeedback(){
		GameManager.instance.GameFeedback ("You cast out your nets");
		AudioManager.instance.PlaySFX (netDownSound);		
	}

	void FishUpFeedback(int fishCount){
		string feedbackText = "Your nets are empty...";
		if (fishCount > 0) {
			feedbackText = "You find " + fishCount + "KG fish in your net!";

			psMain.duration = fishBubbleTime * fishCount + 0.01f;
			fishUpPS.Play ();
			StartCoroutine(PlayFishUpSounds(fishCount));
		}

		GameManager.instance.GameFeedback (feedbackText);
	}

	IEnumerator PlayFishUpSounds(int fishCount){
		yield return new WaitForSeconds (fishUpSoundDelay);

		for (int i = 0; i < fishCount; i++) {
			AudioManager.instance.PlaySFX (fishUpSound);
			yield return new WaitForSeconds (fishBubbleTime);
		}
	}

	void NetBrokenFeedback(){
		GameManager.instance.GameFeedback ("All of your fishes escape!", true);
		AudioManager.instance.PlaySFX (netBrokenSound);
	}
}
