using UnityEngine;
using System;

public interface IRanByGameManager : IComparable<IRanByGameManager>{
	int sortValue{ get; }//higher value means this managed update is called later
	void ManagedUpdate();
}
