using UnityEngine;
using System.Collections;

public class OnHit : MonoBehaviour {


	public GameObject fire;
	public GameObject explosion;
	public GameObject points;

	private GameObject controller;
	private int destroyScore = 100;

	void Start() {

		controller = GameObject.FindGameObjectWithTag ("GameController");


	}

	void OnTriggerEnter2D(Collider2D other) {
		//Debug.Log ("entered collider");
		if (other.tag == "Ground") {
			Object temp = Instantiate (fire, this.gameObject.transform.position + new Vector3(0,0.5f,0) , new Quaternion(0,0,0,0));
			Object.Destroy(temp, 5.0f);
			Destroy (this.gameObject);
		}

		else if (other.tag == "Rocket") {

			points = Instantiate(points,transform.position + new Vector3(0, 1, 0), new Quaternion(0,0,0,0)) as GameObject;
			controller.GetComponent<Spawner>().updateScore(destroyScore);
			GameObject.Destroy(points, 5.0f);
			explosion = Instantiate(explosion, transform.position, new Quaternion(0,0,0,0)) as GameObject;
			GameObject.Destroy(explosion, 2.0f);
			Destroy(other.gameObject);
			Destroy(this.gameObject);
		}

		else if (other.tag == "Explosion") {
			Destroy(this.gameObject);
			points = Instantiate(points,transform.position + new Vector3(0, 1, 0) , new Quaternion(0,0,0,0)) as GameObject;
			controller.GetComponent<Spawner>().updateScore(destroyScore);
			GameObject.Destroy(points, 5.0f);
		}

		else if (other.tag == "Building") {
			Destroy(other.gameObject);
			Destroy(this.gameObject);
			controller.GetComponent<Spawner>().destroyBuilding();
		}

		else if (other.tag == "Player") {
			Destroy(other.gameObject);
			Spawner.endGame();
		}
	}
}
