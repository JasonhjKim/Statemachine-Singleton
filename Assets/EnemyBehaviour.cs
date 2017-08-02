using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour {
	Vector3 velocity;
	float gravity = -5f;
	float margin = 0.30f;
	Rigidbody2D rgbd;
	PlayerController2D controller;

	void Start () {
		rgbd = GetComponent<Rigidbody2D> ();
		controller = GetComponent<PlayerController2D> ();
	}

	void Update () {
		if (controller.collisions.above || controller.collisions.below) {
			velocity.y = 0;
		}
		velocity.y += gravity * Time.deltaTime;

		controller.Move (velocity * Time.deltaTime);
	}
}
