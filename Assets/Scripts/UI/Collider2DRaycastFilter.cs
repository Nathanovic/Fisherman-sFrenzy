using UnityEngine.UI;
using UnityEngine;

[RequireComponent(typeof(RectTransform), typeof(Collider2D))]
public class Collider2DRaycastFilter : MonoBehaviour, ICanvasRaycastFilter {

	private Collider2D myCollider;
	private RectTransform rectTransform;
	private Button myButton;
	private Image myImg;

	public DockStore tradeScript;
	public Permit linkedPermit;

	private bool pointerInside;

	void Awake(){
		myCollider = GetComponent<Collider2D> ();
		rectTransform = GetComponent<RectTransform> ();
		myButton = GetComponent<Button> ();
		myImg = GetComponent<Image> ();
	}

	void Start(){
		UpdateColor ();
		tradeScript.onPermitBought += UpdateColor;
	}

	void Update(){
		if (Input.GetMouseButtonUp (0) && myButton.IsInteractable()) {
			if (ClickedMyCollider (Input.mousePosition)) {
				tradeScript.UpdateSelectedPermitInfo (linkedPermit);
			}
		}
	}

	public bool IsRaycastLocationValid(Vector2 screenPos, Camera eventCamera){
		Vector3 worldPoint = Vector3.zero;
		bool isInside = RectTransformUtility.ScreenPointToWorldPointInRectangle (
			               rectTransform,
			               screenPos,
			               eventCamera,
			               out worldPoint
		);
		if (isInside) {
			isInside = myCollider.OverlapPoint (worldPoint);
		}

		return isInside;
	}

	private bool ClickedMyCollider(Vector2 screenPos){
		Vector3 worldPoint = Vector3.zero;
		bool isInside = RectTransformUtility.ScreenPointToWorldPointInRectangle (
			rectTransform,
			screenPos,
			null,
			out worldPoint
		);
		if (isInside) {
			isInside = myCollider.OverlapPoint (worldPoint);
		}

		return isInside;
	}

	void UpdateColor(){
		if (linkedPermit.unlocked) {
			myImg.color = new Color (0.8f, 0.98f, 0.7f);
		}
		else if (linkedPermit.CanBuyPermit ()) {
			myImg.color = new Color (0.8f, 0.8f, 0.8f);
		}
		else {
			myImg.color = new Color (0.8f, 0.35f, 0.35f);
		}
	}
}
