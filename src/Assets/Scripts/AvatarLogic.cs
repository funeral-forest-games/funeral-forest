using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarLogic : MonoBehaviour {

	private Rigidbody2D rb2d;
	private Vector2 startPos;

	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
		startPos = rb2d.position;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ResetAvatarPosition () {
		rb2d.position = startPos;
	}
}
