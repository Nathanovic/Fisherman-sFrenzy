using UnityEngine;

public static class ExtensionMethods {

	public static void Activate(this CanvasGroup target){
		target.alpha = 1f;
		target.interactable = true;
		target.blocksRaycasts = true;		
	}

	public static void Deactivate(this CanvasGroup target){
		target.alpha = 0f;
		target.interactable = false;
		target.blocksRaycasts = false;
	}
}
