using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateStuff;

public class IdleState : State<AI> {
	private static IdleState _instance;
	private IdleState() {
		if (_instance != null) {
			return;
		}
		_instance = this;
	}

	public static IdleState Instance {
		get { 
			if (_instance == null) {
				new IdleState ();
			}
			return _instance;
		}
	}

	public override void EnterState(AI _owner) {
		Debug.Log ("Entering Idle State");
		_owner.gameObject.GetComponent<Renderer> ().material.color = Color.green;
	}

	public override void ExitState(AI _owner) {
		Debug.Log ("Exiting Idle State");
	}

	public override void UpdateState(AI _owner) {
		if (!_owner.isPatrolling) {
			_owner.transform.position = new Vector2 (_owner.transform.position.x, _owner.transform.position.y);
		} else {
			_owner.stateMachine.ChangeState (PatrolState.Instance);
		}
	}
}
