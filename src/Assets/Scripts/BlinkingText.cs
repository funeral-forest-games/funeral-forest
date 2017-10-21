using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlinkingText : MonoBehaviour {

	private bool isBlinking;
	private Coroutine co;
	private Text text;

	void Start() {
		StartBlinking ();
	}

	public void StartBlinking() {
		isBlinking = true;
		text = GetComponent<Text> ();
		co = StartCoroutine(StartBlinker ());
	}

	public void StopBlinking() {
		StopCoroutine (co);
	}

	private IEnumerator StartBlinker(float duration = .5f) {
		Color color = text.color;
		bool blinkToggle = true;
		while (isBlinking)
		{
			if (blinkToggle) {
				color.a = 0f;
				blinkToggle = false;
			} else {
				color.a = 1.0f;
				blinkToggle = true;
			}
			text.color = color;
			yield return new WaitForSeconds(duration);
		}
	}
}
