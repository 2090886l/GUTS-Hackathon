using UnityEngine;
using System.Collections;

public class RocketSpawn : MonoBehaviour {
	
	public int speed = 10;
	public GameObject explosion;

	private Vector3 targetPosition;
	
	// Use this for initialization
	void Start () {
		
		
		targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		targetPosition.z = 0;
		Debug.Log (targetPosition.x + "  " + targetPosition.y);
		this.gameObject.GetComponent<Rigidbody2D> ().velocity = (targetPosition - transform.position).normalized * speed;
		this.gameObject.transform.rotation = Quaternion.LookRotation (Vector3.forward, targetPosition - transform.position);
		
	}

	void FixedUpdate () {

		if (Vector3.Distance(transform.position,targetPosition) < 0.4) {
			explosion = Instantiate(explosion, transform.position, new Quaternion(0,0,0,0)) as GameObject;
 			GameObject.Destroy(explosion, 2.0f);
			if (this.gameObject != null)
				Destroy(this.gameObject);
			
			
		}
		
	}


	
}
