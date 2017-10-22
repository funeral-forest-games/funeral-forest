using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class AvatarMovement : MonoBehaviour {

	public float speed;             //Floating point variable to store the player's movement speed.

	private Rigidbody2D rb2d;       //Store a reference to the Rigidbody2D component required to use 2D Physics.

	private Camera mainCamera;
	public bool camFollowsAvatar = true;
	public bool avatarLocked = false;

	// Use this for initialization
	void Start()
	{
		rb2d = GetComponent<Rigidbody2D> ();
		mainCamera = Camera.main;
	}

	//FixedUpdate is called at a fixed interval and is independent of frame rate. Put physics code here.
	void FixedUpdate()
	{
		rb2d.velocity = Vector2.zero;
		if (!avatarLocked) {
			//Store the current horizontal input in the float moveHorizontal.
			float moveHorizontal = Input.GetAxis ("Horizontal");

			//Store the current vertical input in the float moveVertical.
			float moveVertical = Input.GetAxis ("Vertical");

			//Use the two store floats to create a new Vector2 variable movement.
			Vector2 movement = new Vector2 (moveHorizontal, moveVertical);

			rb2d.velocity = movement * speed;
		}

		if (camFollowsAvatar) {
			Vector3 lerp = Vector3.Lerp (rb2d.position, mainCamera.transform.position, 10);
			Vector3 camPos = mainCamera.transform.position;
			camPos.x = (camPos.x * 5 + rb2d.position.x) / 6;
			camPos.y = (camPos.y * 5 + rb2d.position.y) / 6;
			mainCamera.transform.position = camPos;
			//mainCamera.transform.position = lerp;
			//mainCamera.transform.position = new Vector3 (rb2d.position.x, rb2d.position.y, mainCamera.transform.position.z);
		}
	}


    void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.CompareTag("PickUp")) {
            other.gameObject.SetActive(false);
			Debug.Log("Hello");
		}
    }
}