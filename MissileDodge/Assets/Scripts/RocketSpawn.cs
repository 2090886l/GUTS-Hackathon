using UnityEngine;
using System.Collections;

public class RocketSpawn : MonoBehaviour {
	
	public int speed = 10;
	
	// Use this for initialization
	void Start () {
		
		
		Vector3 targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		targetPosition.z = 0;

		this.gameObject.GetComponent<Rigidbody2D> ().velocity = (targetPosition - transform.position).normalized * speed;
		this.gameObject.transform.rotation = Quaternion.LookRotation (Vector3.forward, targetPosition - transform.position);
		
	}
	
}
