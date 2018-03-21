using UnityEngine;
using System;

public class ManagedBehaviour : MonoBehaviour, IComparable<ManagedBehaviour>{

	public int sortValue;//higher sort value means called later

	protected virtual void Awake(){
		GameManager.instance.InitGameLoopDependable (this);		
	}

	public virtual void ManagedUpdate(){}
	public virtual void ManagedFixedUpdate(){}

	public int CompareTo (ManagedBehaviour other) {
		return other.sortValue < sortValue ? 1 : other.sortValue == sortValue ? 0 : -1;
	}
}
