using UnityEngine;
using System.Collections;

public class flower : MonoBehaviour {

	public GameObject parahod;
	public GameObject building;

	private Sprite mySprite;
	// Use this for initialization
	void Start () {

		mySprite = building.GetComponent<SpriteRenderer> ().sprite;
	
	}

	void OnTriggerEnter2D(Collider2D other) {

		if (other.tag == "Rocket") {



			Debug.Log ("entered");

			parahod.GetComponent<SpriteRenderer> ().sprite = mySprite;	

		}
	}

	// Update is called once per frame
	void Update () {
	
	}
}
