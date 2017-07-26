using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour {

	public float health = 150f;

	void OnTriggerEnter2D(Collider2D col) {
	
		Projectile projectile = col.gameObject.GetComponent<Projectile>();
		
		if(projectile) {
			health -= projectile.GetDamage();
			projectile.Hit();
			if (health <= 0) {
				Destroy(gameObject);
			}
					
		}
	
	}
	
	
}
