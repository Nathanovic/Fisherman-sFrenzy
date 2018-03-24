using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this script does the visualization for the sonar & minimap
//furthermore this script can be used by other minimap elements to request the minimapPosition
public class Sonar : MonoBehaviour {

	public static Sonar instance;

	private Vector3 previousTargetPos;
	[SerializeField]private Transform target;
	[SerializeField]private Transform map;
	[SerializeField]private Transform rotator;
	[SerializeField]private float rotSpeed;

	void Awake(){
		instance = this;
	}

	void Start(){
		previousTargetPos = target.position;
	}

	private void Update () {
		Vector3 movement = target.position - previousTargetPos;
		map.position = map.position + movement;

		Vector3 targetPos = target.position;
		targetPos.y = transform.position.y;
		transform.position = targetPos;
		rotator.transform.Rotate (Vector3.up * rotSpeed * Time.deltaTime, Space.World);

		previousTargetPos = target.position;
	}

	public Transform GetMinimapTransform(){
		return transform.parent;
	}

	public Vector3 GetMinimapPosition(Vector3 targetWorldPos){
		Vector3 targetOffset = targetWorldPos - target.position;
		targetOffset.y = 0f;
		return transform.position + targetOffset;
	}
}
