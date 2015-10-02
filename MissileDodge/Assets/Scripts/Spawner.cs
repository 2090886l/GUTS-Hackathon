using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {


	public GameObject rocket;
	// Use this for initialization
	void Start () {

		Vector3 spawnPosition = new Vector3 (0, 0, 0);
		rocket =  (GameObject) Instantiate(rocket, spawnPosition, new Quaternion(0,0,0,0));
		rocket.GetComponent<Rigidbody2D> ().velocity = new Vector2 (10, 0);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
