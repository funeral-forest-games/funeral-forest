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

	private float timerValue;
	private float timerDefaultValue;
	private bool isGameOver;
	private int customFrames;
	private string timerGui = "";
	//private Timer timer;

	public GameObject raven;
	private RavenScript ravenScript;
	private bool ravenFlying;

	public GameObject avatar;
	private AvatarLogic avatarLogic;
	private AvatarMovement avatarMovement;

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
		avatarMovement = avatar.GetComponent<AvatarMovement> ();
		ravenScript = raven.GetComponent<RavenScript> ();

		GameStart ();
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape)) {
			Application.Quit();
		}

		if (isGameOver) {
			if (!ravenFlying) {
				ravenScript.ActivateRaven ();
				ravenFlying = true;
				avatarMovement.camFollowsAvatar = false;
				avatarMovement.avatarLocked = true;
			} else {
				if (ravenScript.IsFlyingDone ()) {
					ravenFlying = false;
					avatarMovement.camFollowsAvatar = true;
					ravenScript.Reset ();
					Invoke("UnlockAvatar", 1.3f);
					avatarLogic.ResetAvatarPosition ();
					GameStart ();
				}
			}
		} else {
			if (timerValue <= 0) {
				GameOver ();		
			} else {
				customFrames++;
				timerText.text = timerGui + Mathf.FloorToInt(timerValue);
			}
		}
	}

	private void UnlockAvatar() {
		avatarMovement.avatarLocked = false;
	}

	public void GameStart() {
		isGameOver = false;
		StartCoroutine(StartCountdown(timer));
		timerDefaultValue = timerValue;
		timerText.text = timerGui + Mathf.FloorToInt(timerValue);
		customFrames = 0;
	}

	public void GameOver() {
		//gameOverText.SetActive (true);
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
