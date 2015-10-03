using UnityEngine;
using System.Collections;

public class FireKill : MonoBehaviour {



	private GameObject controller;
	
	void Start() {
		
		controller = GameObject.FindGameObjectWithTag ("GameController");
		
		
	}

	void OnTriggerEnter2D(Collider2D other) {
		//Debug.Log ("entered collider");
		if (other.tag == "Player") {
			Spawner.endGame ();
		}
	}
	

	// Update is called once per frame
	void Update () {
	
	}
}
