using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryCollectable : MonoBehaviour {

	private bool isCollected;
	private SpriteRenderer spriteRenderer;
	private AudioSource itemPickup;

	void Start() {
		isCollected = false;
		spriteRenderer = GetComponent<SpriteRenderer> ();
		itemPickup = GameObject.Find ("ItemPickupSound").GetComponent<AudioSource> ();
		Show ();
	}

	public void OnCollisionEnter2D(Collision2D other) {
		if (isCollected) {
			return;
		}

		if (other.gameObject.GetComponent<Inventory> ()) {
			other.gameObject.GetComponent<Inventory> ().Add (this.gameObject);	
			isCollected = true;
			Hide ();
		}
	}

	public void OnTriggerEnter2D(Collider2D other) {
		if (isCollected) {
			return;
		}

		if (other.GetComponent<Inventory> ()) {
			other.GetComponent<Inventory> ().Add (this.gameObject);	
			itemPickup.Play ();
			isCollected = true;
			Hide ();
		}
	}

	public void handleCollision(GameObject obj) {

	}

	private void Hide() {
		Color color = spriteRenderer.color;
		color.a = 0f;
		spriteRenderer.color = color;
	}

	private void Show() {
		Color color = spriteRenderer.color;
		color.a = 1f;
		spriteRenderer.color = color;
	}
}
