using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonController : MonoBehaviour {

	public float movementSpeed = 5.0f;
	public float mouseSensitivity = -0.0001f;
	public float jumpSpeed = 5.0f;
	private float verticalAngleLimit = 60.0f;
	private float verticalRotation = 0.0f;
	private float verticalVelocity = 0.0f;
	private CharacterController cc;
	// Use this for initialization
	void Start () {
		cc = GetComponent<CharacterController> ();
		Screen.lockCursor = true;
	}
	
	// Update is called once per frame
	void Update () {

		float horizontalRotation = Input.GetAxis ("Mouse X") * mouseSensitivity;
		transform.Rotate (0, -horizontalRotation, 0);

		verticalRotation += Input.GetAxis ("Mouse Y") * mouseSensitivity;
		verticalRotation = Mathf.Clamp (verticalRotation, -verticalAngleLimit, verticalAngleLimit);
		Camera.main.transform.localRotation = Quaternion.Euler (verticalRotation, 0, 0);

		float forwardSpeed = Input.GetAxis ("Vertical") * movementSpeed;
		float horizontalSpeed = Input.GetAxis ("Horizontal") * movementSpeed;


		verticalVelocity += Physics.gravity.y * Time.deltaTime;
		if (Input.GetButton("Jump") && cc.isGrounded) {
			verticalVelocity = jumpSpeed;
			}
		Vector3 speed = new Vector3 (horizontalSpeed, verticalVelocity, forwardSpeed);
		speed = transform.rotation * speed;

		
		cc.Move (speed * Time.deltaTime);
	}
}
