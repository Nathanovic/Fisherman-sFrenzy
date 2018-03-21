using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class VirtualJoystick : MonoBehaviour {

	private RectTransform background;
	private RectTransform joystick;
	private CanvasGroup cvg;
	private CanvasCounter disableCounter;
	[SerializeField]private float cvgDisableTime = 0.8f;
	[SerializeField]private float fadeOutTime = 0.5f;
	//private bool disabledCVG;

	private Vector3 inputVector;
	public Vector3 movementVector;

	public Transform camTransform;
	public float maxInputTouchDist = 90f;

	private bool draggingJoystick = false;
	private bool joystickActive = true;

	private void Start(){
		background = GetComponent<RectTransform> ();
		joystick = transform.GetChild (0).GetComponent<RectTransform> ();

		cvg = GetComponent<CanvasGroup> ();
		disableCounter = new CanvasCounter (cvg, cvgDisableTime, fadeOutTime);
		disableCounter.onCount += DisableCVG;
		//DisableCVG ();

		//avoid the joystick from popping up when the boat should not be controlled
		GameManager.instance.onBoatControlsDisabled += BoatControlsDisabled;
		GameManager.instance.onBoatControlsEnabled += BoatControlsEnabled;
	}

	//called by the inputManager
	public void UpdateJoystick(bool startDragging, bool stopDragging){
		if (!joystickActive)
			return;

		if (startDragging) {
			TryStartDragginJoystick ();
		} 
		else if(stopDragging){
			draggingJoystick = false;
			StopDraggingJoystick ();
		} 
		else if (draggingJoystick) {
			DragPointer ();
		}
	}

	private void TryStartDragginJoystick(){
		Vector2 inputPos = ShipInputManager.instance.inputPosition;
		Vector2 localPoint = new Vector2 ();

		/*
		if (disabledCVG) {
			RectTransformUtility.ScreenPointToLocalPointInRectangle (background, inputPos, null, out localPoint);
			Vector2 normalizedPoint = background.anchoredPosition + localPoint;
			//background.anchoredPosition = normalizedPoint;

			disabledCVG = false;
		}
		else {
			RectTransformUtility.ScreenPointToLocalPointInRectangle (background, inputPos, null, out localPoint);
			if(localPoint.magnitude > maxSecondTouchDist){
				Vector2 normalizedPoint = background.anchoredPosition + localPoint;
				//background.anchoredPosition = normalizedPoint;		

				draggingJoystick = true; 
			}
		}

		if (useDirectionPointer) {
			directionPointer.Enable ();
		}
		*/

		RectTransformUtility.ScreenPointToLocalPointInRectangle (background, inputPos, null, out localPoint);
		if(localPoint.magnitude <= maxInputTouchDist){
			draggingJoystick = true; 
			DragPointer ();
		}
	}

	private void DragPointer (){
		Vector2 inputPos = ShipInputManager.instance.inputPosition;
		Vector2 pos = new Vector2 ();
		if(RectTransformUtility.ScreenPointToLocalPointInRectangle(background,
			inputPos, null, out pos))
		{
			pos.x = pos.x / background.sizeDelta.x;
			pos.y = pos.y / background.sizeDelta.y;

			inputVector = new Vector3 (pos.x * 2f, 0f, pos.y * 2f);
			inputVector = (inputVector.magnitude > 1f) ? inputVector.normalized : inputVector;

			joystick.anchoredPosition = new Vector3 (inputVector.x * background.sizeDelta.x * 0.5f, inputVector.z * background.sizeDelta.y * 0.5f, 0f);

			movementVector = camTransform.TransformDirection (inputVector);
		}
	}

	private void StopDraggingJoystick(){
		//directionPointer.Disable ();
		inputVector = movementVector = Vector3.zero;
		joystick.anchoredPosition = inputVector;
		draggingJoystick = false;
		//disableCounter.StartCounter ();
	}

	private void DisableCVG(){
		disableCounter.StopCounter ();
		//disabledCVG = true;
		cvg.Deactivate ();
	}

	private void EnableCVG(){
		cvg.Activate ();
		disableCounter.StopCounter ();
		DragPointer ();		
	}

	private void BoatControlsDisabled(){
		StopDraggingJoystick ();
		DisableCVG ();
		joystickActive = false;
		draggingJoystick = false;
	}

	private void BoatControlsEnabled(){
		joystickActive = true;
		EnableCVG ();
	}

	public Vector3 GetMoveVector(){
		return movementVector;
	}
}