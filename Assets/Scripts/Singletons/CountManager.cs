using UnityEngine;
using System.Collections.Generic;

public class CountManager : ManagedBehaviour {

	public static CountManager instance;

	private List<Counter> myCounters = new List<Counter>();

	protected override void Awake(){
		base.Awake ();
		instance = this;		
	}

	public void InitCounter(Counter newCounter){
		myCounters.Add (newCounter);
	}

	public override void ManagedUpdate () {
		for(int i = 0; i < myCounters.Count; i ++){
			myCounters [i].Update ();
		} 
	}
}
