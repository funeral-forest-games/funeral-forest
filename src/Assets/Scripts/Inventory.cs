using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {

	public GameObject inventoryGui; 

	private List<GameObject> items;

	void Start() {
		items = new List<GameObject> ();
	}

	void Update() {
	}

	public void Add(GameObject item) {
		GameObject newItem = new GameObject (item.name);
		Image image = newItem.AddComponent<Image> ();
		image.sprite = item.GetComponent<SpriteRenderer> ().sprite;
		newItem.GetComponent<Transform> ().SetParent(inventoryGui.transform);
		//inventoryGui.GetComponentInChildren<Renderer> ().material = item.GetComponent<Renderer> ().material;
		items.Add (newItem);
	}

	public bool ContainsItem(string itemName) {
		for(int i = 0; i < items.Count; i++){
			if(items[i].name == itemName) {
				return true;
			}
		}
		return false;
	}
}
