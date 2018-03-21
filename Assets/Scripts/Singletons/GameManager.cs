using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
	
	public static GameManager instance;
	public Transform sea;
	public Text feedbackText;
	private int currentLevel = 1;
	[SerializeField]private int finalLevel = 2;

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

	public event DefaultDelegate onBoatControlsDisabled;
	public event DefaultDelegate onBoatControlsEnabled;

	void Awake(){
		instance = this;
	}

	void Start(){
		endGameCounter = new Counter ();
		endGameCounter.onCount += ShowEndGameText;
		endGameCounter.StartCounter (mainGameDurationInSecs);
		endWarning = showBigTextDuration.ToString () + endWarning;
		gameText.text = endWarning;

		if (currentLevel == 1) {
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
		else {
			gameIsRunning = true;
		}
	}

	void AddPermit(){
		
	}

	void OnEnvSceneLoaded(Scene newScene, LoadSceneMode loadMode){
		SceneManager.SetActiveScene (newScene);		
	}

	//called on Awake
	public void InitGameLoopDependable(ManagedBehaviour behaviour){
		gameLoopDependables.Add (behaviour);
	}

	public void StartGame(){
		menuPanel.Deactivate ();
		levelInfoScript.ShowLevelInfo (StartPlaying);
	}

	private void StartPlaying(){
		Time.timeScale = 1f;
		gameIsRunning = true;		
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
		feedbackText.text = feedback;
		feedbackText.color = showAsWarning ? Color.red : Color.black;
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

		gameText.enabled = false; 
		gameIsRunning = false;
		ProgressionManager.instance.EvaluateProgress ();
	}

	public void LoadNextLevel(){
		currentLevel++;
		gameText.enabled = true;

		if (currentLevel > finalLevel) {
			gameText.text = "You completed the game!";
			gameIsRunning = false;
		}
		else {
			gameText.text = "Level " + currentLevel.ToString() + " begins!";
			endGameCounter.onCount += DisableGameText;
			endGameCounter.StartCounter (3f);
			Start ();
		}
	}

	void DisableGameText(){
		endGameCounter.onCount -= DisableGameText;
		gameText.enabled = false;
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