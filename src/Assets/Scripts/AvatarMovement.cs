using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class AvatarMovement : MonoBehaviour {

	public float speed;             //Floating point variable to store the player's movement speed.

	private Rigidbody2D rb2d;       //Store a reference to the Rigidbody2D component required to use 2D Physics.

	private AudioSource footsteps;

	private Camera mainCamera;
	public bool camFollowsAvatar = true;
	public bool avatarLocked = true;

	private Animator animator;
	private int direction = 2;
	private bool directionChanged = false;

	// Use this for initialization
	void Start()
	{
		rb2d = GetComponent<Rigidbody2D> ();
		mainCamera = Camera.main;
		footsteps = GetComponent<AudioSource> ();
		animator = GetComponent<Animator>();

		Invoke("UnlockAvatar", 1.5f);
	}

	//FixedUpdate is called at a fixed interval and is independent of frame rate. Put physics code here.
	void FixedUpdate()
	{
		rb2d.velocity = Vector2.zero;
		if (avatarLocked) {
			animator.SetFloat ("Speed", 0);
			if (footsteps.isPlaying) {
				footsteps.Stop ();
			}
		} else {
			//Store the current horizontal input in the float moveHorizontal.
			float moveHorizontal = Input.GetAxis ("Horizontal");

			//Store the current vertical input in the float moveVertical.
			float moveVertical = Input.GetAxis ("Vertical");

			//Use the two store floats to create a new Vector2 variable movement.
			Vector2 movement = new Vector2 (moveHorizontal, moveVertical);

			float currentSpeed = movement.magnitude;

			animator.SetFloat ("Speed", currentSpeed);
			if (currentSpeed > 0) {
			
				if (footsteps.isPlaying == false) {
					footsteps.Play ();
				}
			} else {
				if (footsteps.isPlaying) {
					footsteps.Stop ();
				}
			}

			switch (direction) {
				case 0:
					if (movement.y != 1) {
						directionChanged = true;
					}
					break;
				case 1:
					if (movement.x != 1) {
						directionChanged = true;
					}
					break;
				case 2:
					if (movement.y != -1) {
						directionChanged = true;
					}
					break;
				case 3:
					if (movement.x != -1) {
						directionChanged = true;
					}
					break;
				default:
					break;
			}

			if (directionChanged) {
				if (movement.x > .1) {
					direction = 1;
				} else if (movement.x < -.1) {
					direction = 3;
				} else if (movement.y > .1) {
					direction = 0;
				} else if (movement.y < -.1) {
					direction = 2;
				}
				directionChanged = false;
			}

			

			

			animator.SetInteger ("Direction", direction);
			rb2d.velocity = movement * speed;	
		}

		if (camFollowsAvatar) {
			Vector3 camPos = mainCamera.transform.position;
			camPos.x = (camPos.x * 5 + rb2d.position.x) / 6;
			camPos.y = (camPos.y * 5 + rb2d.position.y) / 6;
			mainCamera.transform.position = camPos;
		}
	}

	private void UnlockAvatar() {
		avatarLocked = false;
	}


    void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.CompareTag("PickUp")) {
            other.gameObject.SetActive(false);
			Debug.Log("Hello");
		}
    }
}
