using UnityEngine;
using UnityEngine.UI;

public class DirectionPointer : MonoBehaviour {

	private Image myImg;
	[SerializeField]private Transform origin;
	[SerializeField]private float originOffset;

	void Start(){
		myImg = GetComponentInChildren<Image> ();
		Disable ();
	}

	public void Enable(){
		myImg.enabled = true;
	}

	public void Rotate(Vector3 moveVector){
		if (moveVector != Vector3.zero) {
			transform.position = origin.position + moveVector * originOffset;
			transform.rotation = Quaternion.LookRotation (moveVector);
		}
	}

	public void Disable(){
		myImg.enabled = false;
	}
}
