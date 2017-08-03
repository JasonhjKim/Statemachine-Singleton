using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	PlayerController2D controller;

	[Header("Player Variables")]
	public float playerMovementSpeed;
	public float playerAttackSpeed;
	public float jumpHeight = 4;
	public float timeToJumpApex = 0.4f;
	public float dashSpeed = 2000;
	public float moveSpeed = 6;

	float acclerationTimeAirborne = 0.01f;
	float acclerationTimeGrounded = 0.1f;
	int keyCounter = 0;
	float impulseDistance = 5;
	float gravity;
	float jumpVelocity;
	Vector3 velocity;
	float velocityXSmoothing;

	//private Variable

	void Start () {
		controller = GetComponent<PlayerController2D> ();
		gravity = -((2 * jumpHeight) / Mathf.Pow (timeToJumpApex, 2));
		jumpVelocity = Mathf.Abs(gravity) * timeToJumpApex;
		print ("Gravity: " + gravity + " Jump Velocity: " + jumpVelocity);
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 input = new Vector2 (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical"));
		if (controller.collisions.above || controller.collisions.below) {
			velocity.y = 0;
		}
		if (Input.GetKeyDown (KeyCode.Space) && controller.collisions.below) {
			velocity.y = jumpVelocity;
		}

		float targetVelocityX = input.x * moveSpeed;
		velocity.x = Mathf.SmoothDamp (velocity.x, targetVelocityX, ref velocityXSmoothing, (controller.collisions.below)?acclerationTimeGrounded:acclerationTimeAirborne);
		velocity.y += gravity * Time.deltaTime;
		controller.Move (velocity * Time.deltaTime);
	}
}
