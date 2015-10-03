using UnityEngine;
using System.Collections;

public class ExplosionOnHit : MonoBehaviour {


	public GameObject explosion;


	private GameObject controller;

	// Use this for initialization
	void Start () {
		controller = GameObject.FindGameObjectWithTag ("GameController");
	}

	void OnTriggerEnter2D(Collider2D other) {

		if (this.CompareTag("Building") && other.CompareTag ("Rocket")) {
			Debug.Log ("test");
			Destroy(other.gameObject);
			explosion = Instantiate(explosion, transform.position, new Quaternion(0,0,0,0)) as GameObject;
			GameObject.Destroy(explosion, 2.0f);
			Debug.Log ("entered collider");
			controller.GetComponent<Spawner> ().destroyBuilding ();
			Destroy (this.gameObject);
	

		}

	}
}
