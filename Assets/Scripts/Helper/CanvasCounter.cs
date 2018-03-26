using UnityEngine;

public class CanvasCounter : Counter {

	private CanvasGroup target;
	private float fadeTime;
	private float startFadeTime;
	private float targetA;
	private float startA;

	public CanvasCounter(CanvasGroup _target, float _countTime, float _fadeTime, float _targetA){
		target = _target;
		countTime = _countTime;
		fadeTime = _fadeTime;
		targetA = _targetA;
		startFadeTime = countTime - fadeTime;
		CountManager.instance.InitCounter (this);
	}

	public override void StartCounter (){
		startA = target.alpha;
		base.StartCounter ();
	}

	protected override void CountDown () {
		float timeDiff = Time.time - startCountTime;
		float remainValue = timeDiff - startFadeTime;
		if (remainValue > 0f) {
			target.alpha = Mathf.Lerp (startA, targetA, remainValue / fadeTime);
		}

		base.CountDown ();
	}

	public void SetTargetA(float _targetA){
		targetA = _targetA;
	}
}
