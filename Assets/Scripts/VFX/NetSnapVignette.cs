using UnityEngine;

public class NetSnapVignette : VignetteVFX {

	public FishingNet netScript;

	void Start () {
		netScript.onNetBroken += EnableNetBrokenVFX;
	}
	
	void EnableNetBrokenVFX(){
		StartCoroutine (FadeVignette (1f));
	}

	public bool check;
	void Update(){
		if (check) {
			check = false;
			EnableNetBrokenVFX ();
		}
	}
}
