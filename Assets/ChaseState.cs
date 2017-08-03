using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateStuff;

public class ChaseState : State<AI>{
	private static ChaseState _instance;
	private ChaseState() {
		if (_instance != null) {
			return;
		}
		_instance = this;
	}

	public static ChaseState Instance {
		get {
			if (_instance == null) {
				new ChaseState();
			}
			return _instance;
		}
	}

	public override void EnterState (AI _owner) {
		_owner.gameObject.GetComponent<Renderer> ().material.color = Color.yellow;
		Debug.Log ("Entering Chase State");
	}

	public override void ExitState (AI _owner) {
		Debug.Log ("Exiting Chase State");
	}

	public override void UpdateState (AI _owner) {
		if (DistanceFromTarget(_owner) >= _owner.attackRange) {
			_owner.transform.position = Vector2.MoveTowards (_owner.transform.position, _owner.target.transform.position, _owner.chaseSpeed * Time.deltaTime);
		} else {
			_owner.stateMachine.ChangeState (AttackState.Instance);
		}

		if (DistanceFromTarget (_owner) >= _owner.chaseRange) {
			_owner.stateMachine.ChangeState (PatrolState.Instance);
		}
	}

	private float DistanceFromTarget(AI _owner) {
		return Vector2.Distance (_owner.target.transform.position, _owner.transform.position);
	}
}