using UnityEngine;
using System.Collections;

public class Cannon : MonoBehaviour {

	public GameObject rocket;

	private int shots = 5;

	public void increaseShots() {
		if (shots < 5) {
			shots++;
		}

	}

	public void fireShots() {
		if (shots > 0) {
			Vector3 spawnPosition = transform.position + new Vector3(0,2,0);
			Instantiate(rocket, spawnPosition, new Quaternion(0,0,0,0));
			shots--;
		}
		
	}
	

	public int getShots() {
		return shots;
	}

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
