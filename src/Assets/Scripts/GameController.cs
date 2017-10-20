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
		isGameOver = false;
		timerText.text = "Timer: " + Mathf.FloorToInt(timer);
	}

	// Update is called once per frame
	void Update () {
		if (isGameOver) {
			if (Input.GetMouseButtonDown (0)) {
				SceneManager.LoadScene(SceneManager.GetActiveScene().name);
			}
		} else {
			timer -= Time.deltaTime;
			if (timer <= 0) {
				GameOver ();		
			} else {
				timerText.text = "Timer: " + Mathf.FloorToInt(timer);
			}
		}
	}

	public void GameOver() {
		gameOverText.SetActive (true);
		isGameOver = true;
		timerText.text = "Time Over!";
	}
}
