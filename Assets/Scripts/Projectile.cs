using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	public float damage = 100f;
	
	float GetDamage() {
		return damage;
	}
	
	void Hit() {
		Destroy(gameObject);
	}

}
