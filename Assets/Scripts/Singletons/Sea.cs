using UnityEngine;

public class Sea : MonoBehaviour {

	public static Sea instance;
	public Vector3 seaCurrent;

	void Awake(){
		instance = this;
	}
}