using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryCollectable : MonoBehaviour {

	private bool isCollected;
	private SpriteRenderer spriteRenderer;

	void Start() {
		isCollected = false;
		spriteRenderer = GetComponent<SpriteRenderer> ();
		Show ();
	}

	public void OnTriggerEnter2D(Collider2D other) {
		if (isCollected) {
			return;
		}

		if (other.GetComponent<Inventory> ()) {
			other.GetComponent<Inventory> ().Add (this.gameObject);	
			isCollected = true;
			Hide ();
		}
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
