using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PermitBound : MonoBehaviour {

	[SerializeField]private PermitBoundState state;

	public bool IsUnlocked(){
		return (state == PermitBoundState.Unlocked);
	}

	public void OpenBound(){
		if (state == PermitBoundState.Unlocked) {
			OpenSelf ();
		} else {
			state = PermitBoundState.Unlocked;
		}
	}

	void OpenSelf(){
		state = PermitBoundState.Open;
		Transform[] children = transform.GetComponentsInChildren<Transform> ();
		foreach (Transform child in children) {
			if (child != transform) {
				child.gameObject.SetActive (false);
			}
		}
	}
}

public enum PermitBoundState{
	Locked,
	Unlocked,
	Open
}
