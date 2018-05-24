using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : MonoBehaviour {

	private float heal = 30f;
	private PlayerHealth playerHealth;

	void Awake(){

		playerHealth = GetComponent<PlayerHealth>();
		healPlayer();
	}

	void healPlayer(){

		playerHealth.playerHealth += heal;
	}
}