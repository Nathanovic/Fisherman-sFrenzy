using UnityEngine;

public class Counter{

	protected float countTime;
	protected float startCountTime;
	private bool count;

	public event DefaultDelegate onCount;

	public Counter(){
		CountManager.instance.InitCounter (this);
	}
	public Counter(float _countTime){
		countTime = _countTime;
		CountManager.instance.InitCounter (this);
	}

	public void StartCounter(float _countTime){
		countTime = _countTime;
		StartCounter ();
	}
	public void StartCounter(){
		count = true;
		startCountTime = Time.time; 	
	}

	public void Update(){
		if (count) {
			CountDown ();
		}
	}

	protected virtual void CountDown(){
		if ((Time.time - startCountTime) >= countTime) {
			startCountTime = Time.time; 
			if (onCount != null) {
				onCount ();			
			}
		}
	}

	public void StopCounter(){
		count = false;
	}
}