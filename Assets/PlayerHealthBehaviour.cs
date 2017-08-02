using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthBehaviour : MonoBehaviour {
	public float maxPlayerHealth;
	float currentHealth;
	// Use this for initialization
	void Start () {
		currentHealth = maxPlayerHealth;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void takeDamage(float dmg) {
		currentHealth -= dmg;
		if (currentHealth <= 0) {
			//Respawn at savepoint location;
		}
	}

	public void takeHeal(float heal) {
		if (currentHealth < 0) {
			currentHealth += heal;
		} else {
			return;
		}
	}
}
