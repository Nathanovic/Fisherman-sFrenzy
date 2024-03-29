﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
	
	public static GameManager instance;
	public DockStore dockScript;
	public Transform sea;
	public Text feedbackText;
	private Counter disableFeedbackTextCounter;

	public Text gameText;
	[SerializeField]private string endWarning = " seconds left! Speed it up!";
	private Counter endGameCounter;

	[Header("Canvas components:")]
	public CanvasGroup menuPanel;
	public LevelInfoDisplayer levelInfoScript;

	[Header("Set to true in builds:")]
	public bool finalBuild;
	public GameObject noBuildObject;

	private bool gameIsRunning;
	private List<ManagedBehaviour> gameLoopDependables = new List<ManagedBehaviour> ();

	[Header("Total game time is these together:")]
	public int mainGameDurationInSecs = 5;
	public float fadeTextInDuration = 4.5f;
	public int showBigTextDuration = 20;

	public Permit startPermit;

	public event DefaultDelegate onSeasonStarted;
	public event DefaultDelegate onTutorialReady;
	public event DefaultDelegate onBoatControlsDisabled;
	public event DefaultDelegate onBoatControlsEnabled;

	public AudioClip gameStartSound;

	void Awake(){
		instance = this;
	}

	void Start(){
		endGameCounter = new Counter ();
		disableFeedbackTextCounter = new Counter (1f);
		disableFeedbackTextCounter.onCount += DisableFeedback;

		gameLoopDependables.Sort ();

		ProgressionManager.instance.AddPermit (startPermit);

		if (finalBuild) {
			menuPanel.Activate ();

			Time.timeScale = 0f;
			noBuildObject.SetActive (false);
			SceneManager.LoadSceneAsync (1, LoadSceneMode.Additive);
			SceneManager.sceneLoaded += OnEnvSceneLoaded;
		}
		else {
			gameIsRunning = true;
		}
	}

	void OnEnvSceneLoaded(Scene newScene, LoadSceneMode loadMode){
		SceneManager.SetActiveScene (newScene);		
	}

	//called on Awake
	public void InitGameLoopDependable(ManagedBehaviour behaviour){
		gameLoopDependables.Add (behaviour);
	}
	public void RemoveGameLoopDependable(ManagedBehaviour behaviour){
		gameLoopDependables.Remove (behaviour);
	}

	public void StartGame(){
		menuPanel.Deactivate ();
		levelInfoScript.ShowLevelInfo (OnLevelInfoClickedAway);
	}

	private void OnLevelInfoClickedAway(){
		if (onTutorialReady != null) {//we spelen de tutorial:
			onTutorialReady ();
		} else {
			StartPlaying ();
		}
	}

	public void StartPlaying(){
		StartNextSeason (1);

		Time.timeScale = 1f;
		gameIsRunning = true;	
		AudioManager.instance.PlaySFX (gameStartSound);
	}

	void Update(){
		if (!gameIsRunning || gameLoopDependables.Count == 0)
			return;

		foreach (ManagedBehaviour behaviour in gameLoopDependables) {
			behaviour.ManagedUpdate ();
		}
	}

	void FixedUpdate(){
		if (!gameIsRunning || gameLoopDependables.Count == 0)
			return;

		foreach (ManagedBehaviour behaviour in gameLoopDependables) {
			behaviour.ManagedFixedUpdate ();
		}
	}

	public void GameFeedback(string feedback, bool showAsWarning = false){
		feedbackText.enabled = true;
		feedbackText.text = feedback;
		feedbackText.color = showAsWarning ? Color.red : Color.black;

		disableFeedbackTextCounter.StartCounter ();
	}

	void DisableFeedback(){
		feedbackText.enabled = false;
	}

	void ShowEndGameText(){
		endGameCounter.onCount -= ShowEndGameText;
		endGameCounter.onCount += StartGameTextTimer;
		endGameCounter.StartCounter (fadeTextInDuration);

		gameText.enabled = true;
	}

	void StartGameTextTimer(){
		endGameCounter.StopCounter ();
		endGameCounter.onCount -= StartGameTextTimer;
		StartCoroutine (GameTextTimer ());
	}

	IEnumerator GameTextTimer(){
		float t = showBigTextDuration;
		while (t > 0f) {
			int timeLeft = Mathf.CeilToInt (t);
			gameText.text = timeLeft.ToString ();
			yield return null;
			t -= Time.deltaTime;
		}

		ProgressionManager.instance.EvaluateProgress ();
		if (ProgressionManager.instance.playerCanContinue) {
			dockScript.EnterDock ();
			dockScript.onDockLeft += OnDockLeft;
		}
		else {
			OnSeasonEnded ();
		}
	}

	void OnDockLeft(){
		dockScript.onDockLeft -= OnDockLeft;	
		OnSeasonEnded ();
	}

	void OnSeasonEnded(){
		DisableBoatControls ();
		gameText.enabled = false; 
		gameIsRunning = false;
		ProgressionManager.instance.ShowResults ();
	}

	public void StartNextSeason(int season){
		gameText.enabled = true;
		gameIsRunning = true;

		gameText.text = "Season " + season.ToString() + " begins!";
		endGameCounter.onCount += StartEndGameCounter;
		endGameCounter.StartCounter (3f);
		EnableBoatControls ();

		if (onSeasonStarted != null) {
			onSeasonStarted ();
		}
	}

	void StartEndGameCounter(){
		endGameCounter.StopCounter ();
		endGameCounter.onCount -= StartEndGameCounter;
		gameText.enabled = false;
		gameText.text = showBigTextDuration.ToString () + endWarning;

		endGameCounter.onCount += ShowEndGameText;
		endGameCounter.StartCounter (mainGameDurationInSecs - 3f);		
	}

	public void ShowGameCompletion(){
		gameText.enabled = true;

		gameText.text = "You completed the game!";
		gameIsRunning = false;
	}

	public void Restart(){
		SceneManager.LoadScene (0);
	}

	//used to prevent the player from controlling the boat:
	public void DisableBoatControls(){
		onBoatControlsDisabled ();
	}

	//used to give back control over the boat to the player
	public void EnableBoatControls(){
		onBoatControlsEnabled ();
	}
}