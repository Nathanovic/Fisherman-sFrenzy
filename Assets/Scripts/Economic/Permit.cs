using UnityEngine;

//dit script zorgt dat de speler iets kan unlocken
//regels hiervoor zijn dat er bij één van de aanliggende PermitBounds een opening is en dat de speler voldoende kilo vis heeft
//if the permit is unlocked, beginnen we met spawnen
public class Permit : MonoBehaviour {

	public bool unlocked;
	public int unlockPrice = 40;
	[SerializeField]private PermitBound[] bounds;

	[HideInInspector]public FishPool[] myFishPools;

	//if one adjacent permitBound is open, the player can buy it
	public bool CanBuyPermit(){
		for (int i = 0; i < bounds.Length; i++) {
			if (bounds [i].IsUnlocked ()) {
				return true;
			}
		}

		return false;
	}

	public void Unlock(){
		unlocked = true;
		for (int i = 0; i < bounds.Length; i++) {
			bounds [i].OpenBound ();
		}

		myFishPools = GetComponentsInChildren<FishPool> ();
		for (int i = 0; i < myFishPools.Length; i++) {
			myFishPools [i].StartSpawning ();
		}	
	}

	#if UNITY_EDITOR_WIN
	void OnDrawGizmos(){
		if (unlocked)
			return;

		for (int i = 0; i < bounds.Length; i++) {
			if (unlocked)
				Gizmos.color = Color.green;
			else if (bounds [i].IsUnlocked ())
				Gizmos.color = Color.yellow;
			else
				Gizmos.color = Color.red;
			
			Gizmos.DrawLine (transform.position, bounds[i].transform.position);
		}
	}
	#endif
}
