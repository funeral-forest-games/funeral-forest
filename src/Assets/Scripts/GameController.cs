using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	public static GameController instance;
	public Text timerText;
	public GameObject gameOverText;

	private float timerValue;
	private bool isGameOver;

	private Timer timer;

	void Awake() {
		if (instance == null) {
			instance = this;
		} else if (instance != this) {
			Destroy (gameObject);
		}
	}

	// Use this for initialization
	void Start () {
		timer = GetComponent<Timer> ();
		GameStart ();
	}

	// Update is called once per frame
	void Update () {
		if (timer.IsDone()) {
			timer.StopTimer ();
			GameStart ();
		} 

		timerText.text = "Timer: " + timer.GetTimerValue();
	}

	public void GameStart() {
		isGameOver = false;
		timer.StartTimer ();
	}

}
