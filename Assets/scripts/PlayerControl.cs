using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

	//movement speed
	public float movementSpeed = 10.0F;
	public float runningSpeed = 20.0F;

	//ground detection
	public float groundDetectionLength = 1;

	//camera reference for forward vector
	public Camera mainCamera;

	//jumping
	public float jumpHeight = 5.0F;
	private bool jump = false;
	public Rigidbody rigidbody;

	//Called at the very beginning of the game
	void Start() {
		this.mainCamera = Camera.main;

		this.rigidbody = GetComponent<Rigidbody> ();
	}

	// Update is called once per frame
	void Update () {
		
		//movement
		Vector3 velocity = new Vector3 ();
		if (Input.GetKey (KeyCode.W)) {
			Vector3 forward = this.mainCamera.transform.forward;
			forward.y = 0.0F;
			velocity += forward * this.movementSpeed * Time.deltaTime;
		}
		if (Input.GetKey (KeyCode.S)) {
			Vector3 forward = this.mainCamera.transform.forward;
			forward.y = 0.0F;
			velocity -= forward * (this.movementSpeed * 0.5F) * Time.deltaTime;
		}
		if (Input.GetKey (KeyCode.A)) {
			Vector3 right = this.mainCamera.transform.right;
			right.y = 0.0F;
			velocity -= right * (this.movementSpeed * 0.75F) * Time.deltaTime;
		}
		if (Input.GetKey (KeyCode.D)) {
			Vector3 right = this.mainCamera.transform.right;
			right.y = 0.0F;
			velocity += right * (this.movementSpeed * 0.75F) * Time.deltaTime;
		}
		if (Input.GetKey (KeyCode.LeftShift)) {
			velocity *= this.runningSpeed / this.movementSpeed;
		}
		if (Input.GetKey (KeyCode.Y)) {
			velocity *= 0.5F;
		}
		if (Input.GetKey (KeyCode.Space)) {
			this.jump = true;
		} else {
			this.jump = false;
		}
		this.transform.localPosition += velocity;

	}

	void FixedUpdate() {

		if (this.jump && this.isObjectGrounded ()) {
			this.rigidbody.velocity += new Vector3 (0.0F, this.jumpHeight, 0.0F);
		}

	}

	private bool isObjectGrounded() {
		Vector3 bottom =  new Vector3(this.transform.position.x, this.transform.position.y - this.transform.localScale.y / 2, this.transform.position.z);
		Debug.DrawRay (bottom, Vector2.down);
		if (Physics.Raycast (bottom, Vector3.down, this.groundDetectionLength)) {
			return true;
		} else {
			return false;
		}
	}
}
