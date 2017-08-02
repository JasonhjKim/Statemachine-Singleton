using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthBehaviour : MonoBehaviour {
	public float maxHealth;
	float currentHealth;

	// Use this for initialization
	void Start () {
		currentHealth = maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void healObject(float heal) {
		if (currentHealth > 0) {
			currentHealth += heal;
		}
	}

	public void damageObject(float dmg) {
		currentHealth -= dmg;

		if (currentHealth <= 0) {
			Destroy (gameObject);
		}
	}
}
