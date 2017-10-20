using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	public static GameController instance;
	public Text timerText;
	public GameObject gameOverText;
	public float timer = 30.0f;

	private float timerValue;
	private bool isGameOver;

	void Awake() {
		if (instance == null) {
			instance = this;
		} else if (instance != this) {
			Destroy (gameObject);
		}
	}

	// Use this for initialization
	void Start () {
		GameStart ();
	}

	// Update is called once per frame
	void Update () {
		if (isGameOver) {
			if (Input.GetMouseButtonDown (0)) {
				SceneManager.LoadScene(SceneManager.GetActiveScene().name);
			}
		} else {
			if (timerValue <= 0) {
				GameOver ();		
			} else {
				timerText.text = "Timer: " + Mathf.FloorToInt(timerValue);
			}
		}
	}

	public void GameStart() {
		isGameOver = false;
		StartCoroutine(StartCountdown(timer));
		timerText.text = "Timer: " + Mathf.FloorToInt(timerValue);
	}

	public void GameOver() {
		gameOverText.SetActive (true);
		isGameOver = true;
		timerText.text = "Time Over!";
	}

	private IEnumerator StartCountdown(float countdownValue = 10) {
		timerValue = countdownValue;
		while (timerValue > 0)
		{
			yield return new WaitForSeconds(1.0f);
			timerValue--;
		}
	}
}
