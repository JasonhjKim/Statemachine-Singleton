using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUIHandler : MonoBehaviour {
	Transform UIPosition;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnGUI()
	{

		Vector2 targetPos;
		targetPos = Camera.main.WorldToScreenPoint (transform.position);

		GUI.Box(new Rect(targetPos.x, Screen.height- asd.y, 60, 20), health + "/" + maxHealth);

	}
}
