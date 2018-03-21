using System.Collections.Generic;
using UnityEngine;

//agent data voor vis, wordt gebruikt door de states om de state te checken
public class FishModel : MonoBehaviour {

	public Vector3 position;
	public FishConfig conf;
	public event DefaultDelegate onCaught;
	public event DefaultDelegate onEscaped;

	public float defaultDistToTargetThreshold = 10f;
	public float DistToTarget(){
		return Vector3.Distance (position, transform.parent.position);
	}

	public Transform net;

	public void CatchMe(Transform net){
		this.net = net;
		onCaught ();
	}

	public void Escape(){
		onEscaped ();
	}
}
