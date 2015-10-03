using UnityEngine;
using System.Collections;

public class ExplosionOnHit : MonoBehaviour {


	private GameObject controller;
	// Use this for initialization
	void Start () {
		controller = GameObject.FindGameObjectWithTag ("GameController");
	}

	void OnTriggerEnter2D(Collider2D other) {

		if (other.tag == "Building") {
			Debug.Log ("entered collider");
			Destroy (other.gameObject);
			controller.GetComponent<Spawner> ().destroyBuilding ();
		}
	}
}
