using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RavenScript : MonoBehaviour {

	private GameObject avatar;
	private Rigidbody2D avatarRb2d;
	private Camera mainCamera;
	private Vector2 avatarOffset;

	public GameObject fadeToBlack;

	private AudioSource ravenSound;

	private Rigidbody2D rb2d;

	private bool attachAvatar;

	// Use this for initialization
	void Start () {
		avatar = GameObject.Find ("Avatar");
		mainCamera = Camera.main;
		avatarRb2d = avatar.GetComponent<Rigidbody2D> ();
		avatarOffset = new Vector2 (0f, 1f);
		rb2d = GetComponent<Rigidbody2D> ();
		ravenSound = GetComponent<AudioSource> ();

		Reset ();
	}
	
	// Update is called once per frame
	void Update () {
		if (attachAvatar) {
			Vector3 p = mainCamera.ScreenToWorldPoint(new Vector3(mainCamera.pixelWidth, 0, mainCamera.nearClipPlane));
			if (avatarRb2d.position.x < p.x + 1f) {
				avatarRb2d.position = rb2d.position - avatarOffset;
			}
		}
	}

	public void ActivateRaven() {
		gameObject.SetActive (true);
		Vector3 p = mainCamera.ScreenToWorldPoint(new Vector3(0f, mainCamera.pixelHeight / 2f, mainCamera.nearClipPlane));
		p.y = avatarRb2d.position.y + 1;
		p.x -= 5f;
		rb2d.position = p;
		rb2d.velocity = new Vector2 (15f, 0f);
		Invoke("PlaySound", 0.3f);
		Invoke("FadeToBlack", 1f);
	}

	private void FadeToBlack() {
		fadeToBlack.GetComponent<Animator> ().StartPlayback ();
	}

	private void PlaySound() {
		ravenSound.Play();
	}
		
	public void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.name == "Avatar") {
			avatar.GetComponent<CircleCollider2D> ().enabled = false;
			attachAvatar = true;
		}
	}

	public bool IsFlyingDone() {
		Vector3 p = mainCamera.ScreenToWorldPoint(new Vector3(mainCamera.pixelWidth, 0, mainCamera.nearClipPlane));
		return rb2d.position.x > p.x + 5;
	}

	public void Reset() {
		attachAvatar = false;
		avatar.GetComponent<CircleCollider2D> ().enabled = true;
		rb2d.position = new Vector2 (-50, -50);
		rb2d.velocity = new Vector2 (0, 0);
		gameObject.SetActive (false);
	}
}
