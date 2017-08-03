using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateStuff;

public class AI : MonoBehaviour {
	public StateMachine<AI> stateMachine { get; set;}
	[Header("Public Variables")]
	public bool isPatrolling = false;
	public bool isChasing = false;
	public float gameTimer;
	public float seconds = 0;
	public GameObject target;
	public float movespeed = 0.5f;

	//Patrol State Variables
	[Space]
	[Header("Patrol Variables")]
	public int patrolTime = 1;
	public float patrolSpeed;

	//Idle State Variables
	[Space]
	[Header("Idle Variables")]
	public int idleTime = 2;

	//Detection State Variables
	[Space]
	[Header("Detection Variables")]
	public float detectionRange = 3;

	//Chase State Variables
	[Space]
	[Header("Chase Variables")]
	public float chaseRange = 5;
	public float chaseSpeed = 2;
	public float backChaseRange = 2;

	//Attack State Variables
	[Space]
	[Header("Attack Variables")]
	public float attackRange = 3;
	public float attackSpeed;
	public float attackDamage;

	private void Start () {
		stateMachine = new StateMachine<AI> (this);
		target = GameObject.FindGameObjectWithTag ("Player");
		stateMachine.ChangeState (IdleState.Instance);
	}
	
	// Update is called once per frame
	private void Update () {
		if (Time.time > gameTimer + 1) {
			gameTimer = Time.time;
			seconds++;
			Debug.Log (seconds);
		}

		if (seconds == idleTime && !isPatrolling && !isChasing) {
			seconds = 0;
			isPatrolling = !isPatrolling;
		}

		if (seconds == patrolTime && isPatrolling && !isChasing) {
			seconds = 0;
			isPatrolling = !isPatrolling;
		}

		if (!isPatrolling && isChasing) {
			
		}

		stateMachine.Update ();
	}
}

// Deciding whether to use Time variable or distance variable