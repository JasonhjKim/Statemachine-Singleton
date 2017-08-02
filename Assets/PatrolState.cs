using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateStuff;

public class PatrolState : State<AI> {
	private static PatrolState _instance;
	private int direction;

	private PatrolState() {
		if (_instance != null) {
			return;
		}
		_instance = this;
	}

	public static PatrolState Instance {
		get { 
			if (_instance == null) {
				new PatrolState ();
			}
			return _instance;
		}
	}

	public override void EnterState (AI _owner) {
		Debug.Log ("Entering Patrol State");
		_owner.gameObject.GetComponent<Renderer> ().material.color = Color.blue;
		NextDirection ();
		Debug.Log ("Direction" + direction);
	}

	public override void ExitState (AI _owner) {
		Debug.Log ("Exiting Patrol State");
	}

	public override void UpdateState (AI _owner) {
		if (_owner.isPatrolling) {
			_owner.transform.position = new Vector2 (_owner.transform.position.x + direction * _owner.movespeed * Time.deltaTime, _owner.transform.position.y);
		} else {
			_owner.stateMachine.ChangeState (IdleState.Instance);
		}
		RaycastHit2D hit = Physics2D.Raycast (_owner.transform.position, Vector2.right * direction, _owner.detectionRange, 1 << LayerMask.NameToLayer("Player"));
		Debug.DrawRay (_owner.transform.position, Vector2.right * direction * _owner.detectionRange, Color.blue);
		if (hit) {
			if (hit.collider.tag  == _owner.target.tag) {
				Debug.Log ("Player found");
				_owner.stateMachine.ChangeState (ChaseState.Instance);
			}

			if (hit.collider.tag != _owner.target.tag) {
				Debug.Log ("Searching....");
				_owner.movespeed = 1.5f;
			}
		}
	}
	private void NextDirection() {

		int temp = Random.Range (0, 2);
		switch (temp) {
		case 0:
			direction = -1;
			break;
		case 1:
			direction = 1;
			break;
		}
	}
}
