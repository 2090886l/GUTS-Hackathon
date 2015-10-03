using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DisplayScore : MonoBehaviour {

	public Text endingScore;

	// Use this for initialization
	void Start () {
		endingScore.text = "Game Over  \n" + "Your score: " + Spawner.score + "\n";
		endingScore.text = endingScore.text + "Press any key to restart.";
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.anyKeyDown) {
			Spawner.score = 0;
			Application.LoadLevel ("Scene1");
		}
	}
}
