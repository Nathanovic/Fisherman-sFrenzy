using UnityEngine;

//this script ensures the fish indicator keeps the right position relative from the player using the Sonar.GetMinimapPosition Vector
public class FishIndicator : MonoBehaviour {

	private Transform target;
	private Renderer myRenderer;
	private const float zPos = 0.55f;

	void Start(){
		myRenderer = GetComponent<Renderer>();
	}

	public void Init(FishModel fishModel){
		float myY = transform.position.y;
		target = fishModel.transform;
		transform.localRotation = Quaternion.Euler (270, 0, 90);
		UpdatePosition ();

		fishModel.onKilled += DestroySelf;
	}

	//update our position if we have been scanned by the sonar
	void OnTriggerEnter(Collider other){
		if (other.tag == "Sonar") {
			UpdatePosition ();
		}
	}

	void UpdatePosition(){
		Vector3 targetPos = Sonar.instance.GetMinimapPosition (target.position);
		transform.position = targetPos;		
	}

	void DestroySelf(){
		Destroy (gameObject);
	}
}
