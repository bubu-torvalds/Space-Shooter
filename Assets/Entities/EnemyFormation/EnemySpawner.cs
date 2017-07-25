using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {
	
	public float width = 10f;
	public float height = 5f;
	public float enemySpeed = 5f;
	public GameObject enemyPrefab;
	public float padding = 1;
	
	private float minPosX;
	private float maxPosX;
	private bool movingRight = true;
	

	// Use this for initialization
	void Start () {	
	
		DetectGameSpace();
				
		foreach(Transform child in transform) {
			GameObject enemy = Instantiate(enemyPrefab, child.transform.position, Quaternion.identity) as GameObject;
			// on l'attache à enemyFormation
			enemy.transform.parent = child;
		}		
	}
	
	public void OnDrawGizmos() {
		Gizmos.DrawWireCube(transform.position, new Vector3(width, height, 0));
	}
	
	// Update is called once per frame
	void Update () {
		
		if (movingRight) {
			transform.position += Vector3.right * enemySpeed * Time.deltaTime;			
		} else {		
			transform.position += Vector3.left * enemySpeed * Time.deltaTime;			
		}
		
		float rightFormationEdge = transform.position.x + (0.5f * width);
		float leftFormationEdge = transform.position.x - (0.5f * width);
		
		if (leftFormationEdge < minPosX || rightFormationEdge > maxPosX) {
			movingRight = !movingRight;
		}		
	
	}
	
	void DetectGameSpace() {
		
		Camera mainCamera = Camera.main;
		
		// distance en Z de la camera au gameobject du joueur
		float distance = transform.position.z - mainCamera.transform.position.z;		
		
		// Position en bas à gauche de la zone de jeu
		Vector3 leftBoundary = Camera.main.ViewportToWorldPoint(new Vector3(0,0,distance));
		
		// Position en bas à droite de la zone de jeu
		Vector3 rightBoundary = Camera.main.ViewportToWorldPoint(new Vector3(1,0,distance));
		
		minPosX = leftBoundary.x + padding;
		maxPosX = rightBoundary.x - padding;
		
	}
}
