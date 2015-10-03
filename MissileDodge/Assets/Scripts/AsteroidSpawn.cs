using UnityEngine;
using System.Collections;

public class AsteroidSpawn : MonoBehaviour {

	public float startX;
	public float endX;


	public int speed = 10;
	// Use this for initialization
	void Start () {


		Vector3 targetPosition = new Vector3 (Random.Range (startX, endX), -5, 0);
		this.gameObject.GetComponent<Rigidbody2D> ().velocity = (targetPosition - transform.position).normalized * speed;
	
	}
	

}
