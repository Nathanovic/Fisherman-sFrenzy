using UnityEngine;

public delegate void DefaultDelegate();

//this script does all of the sensing between the boat and the other triggers
public class ShipInteractions : MonoBehaviour {

	public event DefaultDelegate onDockEntered;
	public delegate void BounceDelegate(Vector3 bounceDir);
	public event BounceDelegate onHitObstacle;

	void OnTriggerEnter(Collider other){
		if (other.tag == "Dock") {
			if (onDockEntered != null) {
				onDockEntered ();
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