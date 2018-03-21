using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sonar : MonoBehaviour {

	[SerializeField]private Transform target;
	[SerializeField]private Transform rotator;
	[SerializeField]private float rotSpeed;

	private void Update () {
		rotator.transform.Rotate (Vector3.up * rotSpeed * Time.deltaTime, Space.World);
		Vector3 targetPos = target.position;
		targetPos.y = transform.position.y;
		transform.position = targetPos;
	}
}
