using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveObject : MonoBehaviour {

	private bool isDone;
	public GameObject key;

	public GameObject doneEvent;

	public GameObject gameOverText;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
		
	public void OnTriggerEnter2D(Collider2D other) {
		if (isDone) {
			return;
		}

		if (other.GetComponent<Inventory> ()) {
			Inventory inventory = other.GetComponent<Inventory> ();
			if (inventory.ContainsItem (key.name)) {
				gameOverText.SetActive (true);
			}
			
			isDone = true;
		}
	}
}
