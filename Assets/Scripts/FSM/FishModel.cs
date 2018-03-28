using System.Collections.Generic;
using UnityEngine;

//agent data voor vis, wordt gebruikt door de states om de state te checken
public class FishModel : MonoBehaviour {

	public FishPool myPool;
	public Vector3 position;
	public FishConfig conf;
	public FishSpecie specie;
	public event DefaultDelegate onCaught;
	public event DefaultDelegate onEscaped;
	public event DefaultDelegate onKilled;

	public float defaultDistToTargetThreshold = 10f;
	public float DistToTarget(){
		return Vector3.Distance (position, transform.parent.position);
	}

	public Transform net;

	public void Init(FishPool pool){
		myPool = pool;
		specie = pool.specie;
	}

	public void CatchMe(Transform net){
		this.net = net;
		onCaught ();
	}

	public void Escape(FishPool alternativePool = null){	
		if (alternativePool != null && alternativePool.specie == specie) {
			myPool = alternativePool;
		}

		onEscaped ();
	}

	public void Kill(){
		if (onKilled != null) {
			onKilled ();
		}
		Destroy (gameObject);
	}
}
