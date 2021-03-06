﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorObject : MonoBehaviour {

	private bool isDone;
	public GameObject key;

	public GameObject childObj, childObj2;

	private AudioSource idleAudio, touchAudio, doneAudio;

	// Use this for initialization
	void Start () {
		AudioSource[] sources = GetComponents<AudioSource> ();
		idleAudio = sources [0];
		touchAudio = sources [1];
		doneAudio = sources [2];
	}
	
	// Update is called once per frame
	void Update () {
		
	}



	public void OnCollisionEnter2D(Collision2D collision) {
		if (isDone) {
			return;
		}

		if (collision.gameObject.GetComponent<Inventory> ()) {
			Inventory inventory = collision.gameObject.GetComponent<Inventory> ();
			if (inventory.ContainsItem (key.name)) {
				gameObject.GetComponent<SpriteRenderer> ().enabled = false;
				if (childObj) {
					childObj.GetComponent<SpriteRenderer> ().enabled = false;
				}
				if (childObj2) {
					childObj2.GetComponent<SpriteRenderer> ().enabled = false;
				}
				gameObject.GetComponent<Collider2D> ().enabled = false;
				isDone = true;
				idleAudio.Stop ();
				doneAudio.Play ();
			}
		}
	}
		
	public void OnTriggerEnter2D(Collider2D other) {
		if (isDone) {
			return;
		}

		if (other.GetComponent<Inventory> ()) {
			Inventory inventory = other.GetComponent<Inventory> ();
			if (inventory.ContainsItem (key.name)) {
				gameObject.GetComponent<SpriteRenderer> ().enabled = false;
				if (childObj) {
					childObj.GetComponent<SpriteRenderer> ().enabled = false;
				}
				if (childObj2) {
					childObj2.GetComponent<SpriteRenderer> ().enabled = false;
				}
				gameObject.GetComponent<Collider2D> ().enabled = false;
				isDone = true;
				idleAudio.Stop ();
				doneAudio.Play ();
			}
		}
	}
}
