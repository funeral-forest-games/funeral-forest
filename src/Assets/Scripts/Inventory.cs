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
		Debug.Log (item);
		GameObject newItem = new GameObject (item.name);
		Image image = newItem.AddComponent<Image> ();
		image.sprite = item.GetComponent<SpriteRenderer> ().sprite;
		newItem.GetComponent<Transform> ().SetParent(inventoryGui.transform);
		//inventoryGui.GetComponentInChildren<Renderer> ().material = item.GetComponent<Renderer> ().material;
		items.Add (newItem);
	}

	public bool ContainsItem(string itemName) {
		Debug.Log (itemName);
		for(int i = 0; i < items.Count; i++){
			Debug.Log ("ITEM " + items [i].name);
			if(items[i].name == itemName) {
				return true;
			}
		}
		return false;
	}
}
