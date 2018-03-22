using UnityEngine;

public class CanvasCounter : Counter {

	private CanvasGroup target;
	private float fadeTime;
	private float startFadeTime;
	private float targetA;

	public CanvasCounter(CanvasGroup _target, float _countTime, float _fadeTime, float _targetA){
		target = _target;
		countTime = _countTime;
		fadeTime = _fadeTime;
		targetA = _targetA;
		startFadeTime = countTime - fadeTime;
		CountManager.instance.InitCounter (this);
	}

	protected override void CountDown () {
		float timeDiff = Time.time - startCountTime;
		float remainValue = timeDiff - startFadeTime;
		if (remainValue > 0f) {
			target.alpha = Mathf.Lerp (1f, targetA, remainValue / fadeTime);
		}

		base.CountDown ();
	}
}
