using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour {

	public float timer;

	private float timerValue;
	private bool isRunning;
	private Coroutine co;

	public void StartTimer() {
		co = StartCoroutine (StartCountdown (timer));
	}

	public void StopTimer() {
		StopCoroutine (co);
		isRunning = false;
	}

	public bool IsDone() {
		return isRunning;
	}

	public int GetTimerValue() {
		return Mathf.FloorToInt (timerValue);
	}

	private IEnumerator StartCountdown(float countdownValue = 10) {
		timerValue = countdownValue;
		isRunning = true;
		while (timerValue > 0)
		{
			yield return new WaitForSeconds(1.0f);
			timerValue--;
		}
		isRunning = false;
	}
}
