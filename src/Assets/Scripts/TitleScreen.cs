using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour {

	public Texture imageToDisplay;
	public Texture imageLogo;
	public float timeForFade;
	public string nextLevelToLoad;

	private float timeStart;
	private float timeFadeOutStart;
	private bool isSwitching;

	public void Start() {
		timeStart = Time.time;
	}

	public void OnGUI() {
		Color color;
		if (Time.time <= timeStart + timeForFade) {
			// STARTFADE
			color = new Color (1, 1, 1, Map(Time.time, timeStart, timeStart + timeForFade, 0f, 1f));
		} else {
			// STAY
			color = new Color (1, 1, 1, 1);
		} 

		if (isSwitching) {
			// FADEOUT
			color = new Color (1, 1, 1, Map(Time.time, timeFadeOutStart, timeFadeOutStart + timeForFade, 1f, 0f));
		}

		GUI.color = color;
		GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), imageToDisplay);
		if (imageLogo) {
			GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), imageLogo);
		}

		if (Input.anyKeyDown && !isSwitching) {
			isSwitching = true;
			timeFadeOutStart = Time.time;
		}

		if (isSwitching && Time.time >= timeFadeOutStart + timeForFade) {
			SceneManager.LoadScene(nextLevelToLoad);
		}
	}

	public float Map(float x, float in_min, float in_max, float out_min, float out_max) {
		return (x - in_min) * (out_max - out_min) / (in_max - in_min) + out_min;
	}
}