using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMotor : MonoBehaviour {
	[SerializeField]
	private Camera cam;
	private Vector3 velocity = Vector3.zero;
	private Vector3 rotation = Vector3.zero;
	private Vector3 cameraRotation = Vector3.zero;

	private Rigidbody rb;
	void Start () {
		rb = GetComponent<Rigidbody>();
	}

	public void Move(Vector3 velocities){
		velocity = velocities;
	}
	public void Rotate(Vector3 rotationes){
		rotation = rotationes;
	}
	public void RotateCamera(Vector3 cameraRotationes){
		cameraRotation = cameraRotationes;
	}
	void FixedUpdate () {
		PerformMovement();
		PerformRotation();
	}

	void PerformMovement(){
		if (velocity != Vector3.zero){
			rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
		}
	}
	void PerformRotation(){
		rb.MoveRotation(rb.rotation * Quaternion.Euler (rotation));
		if (cam != null){
			cam.transform.Rotate(-cameraRotation);
		}
	}

	public void Jump(float jumpSpeed){
		rb.AddForce(new Vector3(0, jumpSpeed, 0), ForceMode.Impulse);
	}
}
