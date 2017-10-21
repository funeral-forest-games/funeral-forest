using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	public static GameController instance;
	public Text timerText;
	public GameObject gameOverText;
	public float timer = 100.0f;
	public Light lampLight;

	private float timerValue;
	private float timerDefaultValue;
	private bool isGameOver;
	private float lampLightRange;
	private int customFrames;

	public GameObject avatar;
	private AvatarLogic avatarLogic;

	void Awake() {
		if (instance == null) {
			instance = this;
		} else if (instance != this) {
			Destroy (gameObject);
		}
	}

	// Use this for initialization
	void Start () {
		avatarLogic = avatar.GetComponent<AvatarLogic> ();
		GameStart ();
	}

	// Update is called once per frame
	void Update () {
		if (isGameOver) {
			avatarLogic.ResetAvatarPosition ();
			GameStart ();
		} else {
			if (timerValue <= 0) {
				GameOver ();		
			} else {
				customFrames++;
				timerText.text = "Timer: " + Mathf.FloorToInt(timerValue);

				lampLightRange = ((Mathf.Pow (((customFrames / timerDefaultValue)), -1) / 18) * 1000) + 1;

				if (lampLightRange >= 15) {
					lampLightRange = 15;
				}

				lampLight.range = lampLightRange;
			}
		}
	}

	public void GameStart() {
		isGameOver = false;
		StartCoroutine(StartCountdown(timer));
		timerDefaultValue = timerValue;
		timerText.text = "Timer: " + Mathf.FloorToInt(timerValue);
		lampLight.range = 15;
		customFrames = 0;
	}

	public void GameOver() {
		//gameOverText.SetActive (true);
		isGameOver = true;
		timerText.text = "Time Over!";
		lampLight.range = 15;
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
