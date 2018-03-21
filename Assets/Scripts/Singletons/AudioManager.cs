using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

	public static AudioManager instance;

	public AudioSource sfxSource;
	public AudioSource musicSource;

	void Awake(){
		instance = this;
	}

	public void PlaySFX(AudioClip clip, float volume = 1f){
		sfxSource.PlayOneShot (clip, volume);
	}
}
