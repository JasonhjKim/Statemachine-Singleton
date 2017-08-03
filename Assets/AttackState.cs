using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateStuff;

public class AttackState : State<AI>{
	public static AttackState _instance;

	private AttackState() {
		if (_instance != null) {
			return;
		}
		_instance = this;
	}

	public static AttackState Instance {
		get {
			if (_instance == null) {
				new AttackState ();
			}
			return _instance;
		}
	}

	public override void EnterState (AI _owner) {
		_owner.gameObject.GetComponent<Renderer> ().material.color = Color.red;
		Debug.Log ("Entering Attack State");
	}

	public override void ExitState (AI _owner) {
		Debug.Log ("Exiting Attack State");
	}

	public override void UpdateState(AI _owner) {
		Debug.Log (DistanceFromTarget (_owner));
		if (DistanceFromTarget (_owner) > _owner.attackRange) {
			_owner.stateMachine.ChangeState (ChaseState.Instance);
		}
		Debug.Log("Currently Attacking");
	}

	private float DistanceFromTarget(AI _owner) {
		return Vector2.Distance (_owner.target.transform.position, _owner.transform.position);
	}
}
