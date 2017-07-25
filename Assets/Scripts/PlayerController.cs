using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float minPosX = 0.5f;
	public float maxPosX = 15.5f;
	public float shipSpeed = 15f;
	
	private Vector3 shipPosition;

	// Use this for initialization
	void Start () {
		shipPosition = new Vector3(minPosX, this.transform.position.y, 0);
	}
	
	// Update is called once per frame
	void Update () {		
		
		if (Input.GetKey(KeyCode.LeftArrow)) {
		
			shipPosition.x -= shipSpeed * Time.deltaTime;
			
		} else if (Input.GetKey(KeyCode.RightArrow)) {
			
			shipPosition.x += shipSpeed * Time.deltaTime;
		
		}
		
		shipPosition.x = Mathf.Clamp(shipPosition.x, -maxPosX, maxPosX);
		
		this.transform.position = shipPosition;
	
	}
}
