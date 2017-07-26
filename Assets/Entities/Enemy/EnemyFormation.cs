﻿using UnityEngine;
using System.Collections;

public class EnemyFormation : MonoBehaviour {

	public float health = 150f;
	public GameObject projectile;
	public float projectileSpeed;
	public float shotsPerSeconds = 0.5f;
	public int scoreValue = 150;
	
	private ScoreKeeper scoreKeeper;
	
	void Start() {
		scoreKeeper = GameObject.Find("Score").GetComponent<ScoreKeeper>();
	}

	void OnTriggerEnter2D(Collider2D col) {
	
		Projectile projectile = col.gameObject.GetComponent<Projectile>();
		
		
		if(projectile) {
			health -= projectile.GetDamage();
			projectile.Hit();
			if (health <= 0) {
				Destroy(gameObject);
				scoreKeeper.Score(scoreValue);
			}
					
		}
	}	
	
	void Fire() {		
		Vector3 startPosition = transform.position + new Vector3(0, -1, 0);	
		GameObject laser = Instantiate(projectile, startPosition, Quaternion.identity) as GameObject;			
		laser.rigidbody2D.velocity = new Vector3(0, -projectileSpeed, 0);
	}
	
	void Update() {	
		float probability = Time.deltaTime * shotsPerSeconds;
		if (Random.value < probability) {
			Fire ();
		}
	}	
}