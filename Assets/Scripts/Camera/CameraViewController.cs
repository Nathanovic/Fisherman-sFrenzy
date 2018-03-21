using UnityEngine;

[RequireComponent(typeof(CameraModel))]
public class CameraViewController : MonoBehaviour {

	private Transform target;
	private Vector3 relCamPos;//not-fixed camera
	private Vector3 camDirFromTarget;//fixed camera
	private CameraModel modelScript;

	void Start(){
		modelScript = GetComponent<CameraModel> ();
	}

	public void StartTracking (Transform _target) {
		target = _target;
		relCamPos = target.InverseTransformPoint (transform.position);
		camDirFromTarget = transform.position - target.position;
	}

	void FixedUpdate () {
		if (modelScript.fixedCamera) {
			FixedCameraBehaviour ();
		}
		else {
			FlexibleCameraBehaviour ();
		}
	}

	void FixedCameraBehaviour(){
		transform.position = target.position + camDirFromTarget;
	}

	void FlexibleCameraBehaviour(){
		Vector3 targetPos = target.TransformPoint (relCamPos);
		transform.position = Vector3.Lerp (transform.position, targetPos, modelScript.lerpSpeed * Time.fixedDeltaTime);

		Vector3 lookDir = target.position - transform.position;
		transform.rotation = Quaternion.Lerp (transform.rotation, Quaternion.LookRotation (lookDir), modelScript.rotationSpeed * Time.fixedDeltaTime);
	}
}
