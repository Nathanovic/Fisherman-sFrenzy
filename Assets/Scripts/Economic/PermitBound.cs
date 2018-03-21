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
			state = PermitBoundState.Open;
			GetComponent<Collider> ().enabled = false;
			GetComponent<Renderer> ().enabled = false;
		} else {
			state = PermitBoundState.Unlocked;
		}
	}
}

public enum PermitBoundState{
	Locked,
	Unlocked,
	Open
}
