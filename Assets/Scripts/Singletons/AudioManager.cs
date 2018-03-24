using System.Collections;
using UnityEngine;

public class AudioManager : MonoBehaviour {

	public static AudioManager instance;

	public AudioSource sfxSource;
	public AudioSource musicSource;

	public float fadeDuration = 0.5f;
	public AudioClip cheerfulMusic;
	public AudioClip neutralMusic;
	public AudioClip sadMusic;
	private AudioClip currentMusic;

	private bool gameRunning = true;

	void Awake(){
		instance = this;
	}

	void Start(){
		ProgressionManager.instance.onGameOver += FadeToSadMusic;
		GameManager.instance.onGameStarted += OnGameStarted;
		currentMusic = cheerfulMusic;
		StartCoroutine (PlayMainMusic ());
	}

	IEnumerator PlayMainMusic(){
		while (gameRunning) {
			//wissel tussen 2 clips:
			yield return new WaitUntil (() => !musicSource.isPlaying);
			if (gameRunning) {
				currentMusic = currentMusic == cheerfulMusic ? neutralMusic : cheerfulMusic;
				musicSource.clip = currentMusic;
				musicSource.Play ();
			}
		}	
	}

	public void PlaySFX(AudioClip clip, float volume = 1f){
		sfxSource.PlayOneShot (clip, volume);
	}

	void FadeToSadMusic(){
		gameRunning = false;
		musicSource.loop = true;
		StartCoroutine (FadeMusic (sadMusic, fadeDuration));
	}

	void OnGameStarted(){
		if (!gameRunning) {
			gameRunning = true;
			musicSource.loop = false;
			StartCoroutine (FadeMusic (cheerfulMusic, fadeDuration));
		}
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
