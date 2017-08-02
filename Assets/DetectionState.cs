using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateStuff;

public class DetectionState : State<AI>{
	private static DetectionState _instance;
	private DetectionState() {
		if (_instance != null) {
			return;
		}
		_instance = this;
	}

	public static DetectionState Instance {
		get {
			if (_instance == null) {
				new DetectionState();
			}
			return _instance;
		}
	}

	public override void EnterState (AI _owner) {
	}

	public override void ExitState (AI _owner) {
	}

	public override void UpdateState (AI _owner) {
	}
}
