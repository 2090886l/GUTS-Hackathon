using UnityEngine;
using System.Collections;

public class OnHit : MonoBehaviour {

	private GameObject controller;
	private int destroyScore = 10;

	void Start() {

		controller = GameObject.FindGameObjectWithTag ("GameController");


	}

	void OnTriggerEnter2D(Collider2D other) {
		//Debug.Log ("entered collider");
		if (other.tag == "Ground") {
			Destroy (this.gameObject);
		}

		else if (other.tag == "Rocket") {
			Destroy(other.gameObject);
			Destroy(this.gameObject);
			controller.GetComponent<Spawner>().updateScore(destroyScore);
		}

		else if (other.tag == "Building") {
			Destroy(other.gameObject);
			Destroy(this.gameObject);
			controller.GetComponent<Spawner>().destroyBuilding();
		}

		else if (other.tag == "Player") {
			Destroy(other.gameObject);
			Application.LoadLevel (Application.loadedLevel);
		}
	}
}
