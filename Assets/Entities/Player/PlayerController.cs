using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	private float minPosX;
	private float maxPosX;
	public float shipSpeed = 15f;
	public float padding = 1;
	

	// Use this for initialization
	void Start () {
	
		DetectGameSpace();
	}
	
	// Update is called once per frame
	void Update () {		
		
		if (Input.GetKey(KeyCode.LeftArrow)) {			
			transform.position += Vector3.left * shipSpeed * Time.deltaTime;			
		} else if (Input.GetKey(KeyCode.RightArrow)) {		
			transform.position += Vector3.right * shipSpeed * Time.deltaTime;		
		}	
		
		// pour restreindre la position du joueur dans la zone de jeu
		float newX = Mathf.Clamp(transform.position.x, minPosX, maxPosX);
		
		transform.position = new Vector3(newX, transform.position.y, transform.position.z);
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
