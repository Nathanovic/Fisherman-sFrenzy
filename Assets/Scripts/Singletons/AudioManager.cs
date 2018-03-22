using System.Collections;
using UnityEngine;

public class AudioManager : MonoBehaviour {

	public static AudioManager instance;

	public AudioSource sfxSource;
	public AudioSource musicSource;

	public AudioSource cheerfulMusic;
	public AudioSource neutralMusic;
	public AudioSource sadMusic;

	private bool gameRunning = true;

	void Awake(){
		instance = this;
	}

	void Start(){
		ProgressionManager.instance.onGameOver += FadeToSadMusic;
	}

	IEnumerator PlayMainMusic(){
		while (gameRunning) {
			//wissel tussen 2 clips
		}	
	}

	public void PlaySFX(AudioClip clip, float volume = 1f){
		sfxSource.PlayOneShot (clip, volume);
	}

	void FadeToSadMusic(){
		Debug.Log ("fade to sad music!");
		gameRunning = false;
		StartCoroutine (FadeMusic (sadMusic, 0.5f));
	}

	IEnumerator FadeMusic(AudioClip nextClip, float fadeDuration){
		float t = 0f;
		while (t < 1f) {
			t += Time.deltaTime / fadeDuration;
			musicSource.volume = 1 - t;
			yield return null;
		}

		musicSource.clip = nextClip;
		musicSource.Play ();

		t = 0f;
		while (t < 1f) {
			t += Time.deltaTime / fadeDuration;
			musicSource.volume = t;
			yield return null;
		}
	}
}
