using UnityEngine;

//vangt alle input af mbv InputHandler.cs
//al deze input is relevant voor de besturing van het schip
public class ShipInputManager : ManagedBehaviour {

	private static ShipInputManager _instance;
	public static ShipInputManager instance{
		get{ 
			return _instance;
		}
	}

	[SerializeField]private VirtualJoystick joystickScript;

	private InputHandler inputHandler;

	private float previousTabMoment = -1f;
	[SerializeField]private float doubleTabTime = 0.3f;

	//all of the input values that can be used by other scripts:
	public Vector3 movement{ get; private set;}
	private bool isDragging;
	private bool startDragging;
	private bool stopDragging;
	public bool doubleTapped{ get; private set;}
	public Vector2 inputPosition{ get; private set;}

	public Vector3 inputVec, moveVec;

	public float horizontalInput{ get; private set;}

	protected override void Awake(){
		base.Awake ();
		_instance = this;
	}

	private void Start () {
		if (inputHandler == null) {
			SetUpInputHandler ();
		}
	}

	private void SetUpInputHandler(){
		if (Application.platform == RuntimePlatform.Android)
			inputHandler = new TouchInputHandler ();
		else
			inputHandler = new MouseInputHandler();
	}

	public void AddNotClickable(RectTransform noInputEle){
		if (inputHandler == null)
			SetUpInputHandler ();

		inputHandler.AddNoInputElement (noInputEle);
	}

	public override void ManagedUpdate () {
		inputPosition = inputHandler.PointerPos ();
		startDragging = stopDragging = doubleTapped = false;

		//set pointer-drag values:
		if (!isDragging) {
			if (inputHandler.PointerDown ()) {
				startDragging = true;
				isDragging = true;
			}
		}
		else {
			if (inputHandler.PointerUp ()) {
				stopDragging = true;
				isDragging = false;
			}
		}

		//check for double tap:
		if (inputHandler.PointerUp ()) {
			float tapMoment = Time.time;	

			if ((tapMoment - previousTabMoment) <= doubleTabTime) {
				doubleTapped = true;
				previousTabMoment = -1f;//prevent two double taps in three finger-taps
			}
			else {
				previousTabMoment = tapMoment;
			}
		}

		//set movementVector using the tap-input we received and putting this in the joystickScript:
		joystickScript.UpdateJoystick(startDragging, stopDragging);
		horizontalInput = 0f;
		float v = 0f;
		Vector3 joystickMoveVector = moveVec = joystickScript.GetMoveVector ();

		if (joystickMoveVector.sqrMagnitude > 0f) {
			Vector3 inputVector = inputVec = transform.InverseTransformDirection (joystickMoveVector);

			v = inputVector.magnitude;
			horizontalInput = inputVector.x;
			if (inputVector.z < 0f) {
				if (horizontalInput < 0f) {
					horizontalInput = -1f;
				}
				else {
					horizontalInput = 1f;
				}
			}
		}

		movement = new Vector3 (horizontalInput, 0, v);
	}
}
