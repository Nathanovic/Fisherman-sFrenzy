using UnityEngine;

public delegate void DefaultDelegate();

//this script does all of the sensing between the boat and the other triggers/colliders
//other scripts can use the events that will be called when the boat interacts
public class ShipInteractions : MonoBehaviour {

	public event DefaultDelegate onDockEntered;
	public delegate void BounceDelegate(Vector3 bounceDir);
	public event BounceDelegate onHitObstacle;
	public delegate void FishPoolDelegate(FishPool poolScript);
	public event FishPoolDelegate onFishPoolEntered;
	public event FishPoolDelegate onFishPoolLeft;

	void OnTriggerEnter(Collider other){
		if (other.tag == "Dock") {
			if (onDockEntered != null) {
				onDockEntered ();
			}
		} else if (other.tag == "FishPool") {
			if (onFishPoolEntered != null) {
				onFishPoolEntered (other.GetComponent<FishPool> ());
			}
		}
	}

	void OnTriggerExit(Collider other){
		if (other.tag == "FishPool") {
			if (onFishPoolLeft != null) {
				onFishPoolLeft (other.GetComponent<FishPool> ());
			}
		}
	}

	void OnCollisionEnter(Collision coll){
		if (coll.collider.tag == "Obstacle") {
			float bounceForce = coll.relativeVelocity.magnitude;
			Vector3 bounceDir = coll.contacts [0].normal;
			bounceDir.y = 0f;
			bounceDir = bounceDir.normalized * bounceForce;
			onHitObstacle (bounceDir);
		}
	}
}