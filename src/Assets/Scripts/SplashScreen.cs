using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScreen : MonoBehaviour {

	public Texture imageToDisplay;
	public float timeToDisplayImage;
	public string nextLevelToLoad;

	private float timeForNextLevel;
	private float timeForFade;
	private float timeStart;

	public void Start() {
		timeStart = Time.time;
		timeForNextLevel = Time.time + timeToDisplayImage;
		timeForFade = timeForNextLevel / 4;
	}

	public void OnGUI() {
		float alpha = 1f;
		if (Time.time <= timeStart + timeForFade) {
			// FADEIN
			alpha = Map(Time.time, timeStart, timeStart + timeForFade, 0f, 1f);
		} else if (Time.time >= timeStart + (3 * timeForFade)) {
			// FADEOUT
			alpha = Map(Time.time, timeStart + (3 * timeForFade), timeForNextLevel, 1f, 0f);
		}

		Color color = new Color (1, 1, 1, alpha);
		GUI.color = color;
		GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), imageToDisplay);

		if (Time.time >= timeForNextLevel) {
			SceneManager.LoadScene(nextLevelToLoad);
		}
	}

	public float Map(float x, float in_min, float in_max, float out_min, float out_max) {
		return (x - in_min) * (out_max - out_min) / (in_max - in_min) + out_min;
	}
}

