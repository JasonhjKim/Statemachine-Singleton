using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	PlayerController2D controller;

	[Header("Player Variables")]
	public float playerMovementSpeed;
	public float playerAttackSpeed;

	//private Variables
	private Vector2 input;
	private Vector2 velocity;

	void Start () {
		controller = GetComponent<PlayerController2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

		velocity.x += input.x * playerMovementSpeed * Time.deltaTime;

		controller.Move (velocity * Time.deltaTime);
	}
}
