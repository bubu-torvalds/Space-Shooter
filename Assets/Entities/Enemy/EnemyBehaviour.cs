using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D col) {
	
		Projectile projectile = col.gameObject.GetComponent<Projectile>();
		
		if(projectile) {
			Debug.Log ("touché");
					
		}
	
	}
	
	
}
