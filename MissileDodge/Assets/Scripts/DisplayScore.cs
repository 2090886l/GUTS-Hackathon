using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DisplayScore : MonoBehaviour {

	public Text endingScore;
	public int highScore;

	// Use this for initialization
	void Start () {
		highScore = PlayerPrefs.GetInt ("Current", 0);
		endingScore.text =  "Your score: " + Spawner.score + "\n" + "\n";

		if (Spawner.score > highScore) {
			endingScore.text = endingScore.text + "Current highscore: " ;
			endingScore.text = endingScore.text + Spawner.score + "\n\n";
		} else {
			endingScore.text = endingScore.text + "Current highscore: " ;
			endingScore.text = endingScore.text + highScore ;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Spawner.score > highScore) {
			PlayerPrefs.SetInt ("Current", Spawner.score);
			PlayerPrefs.Save ();
		}
		if (Input.anyKeyDown) {
			Spawner.score = 0;
			Application.LoadLevel ("Scene1");
		

	    }
	}
}
