using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Spawner : MonoBehaviour {


	public GameObject rocket;
	public float speed;
	public float startX;
	public float endX;
	public float roof;
	public Text text;
	public static int score;

	private int spawnScore = 100;
	private int buildings;
	private Vector3 targetPosition;
	private GameObject[] cannons;

	// Use this for initialization
	void Start () {

		buildings = 6;
		cannons = GameObject.FindGameObjectsWithTag ("Cannon");
		StartCoroutine (SpawnWaves());
		StartCoroutine (ReloadRockets ());
	
	}
	
	// Update is called once per frame
	void Update () {
	
	//	float step = speed * Time.deltaTime;
		//rocket.transform.position = Vector3.MoveTowards(rocket.transform.position, targetPosition, step);
	}

	IEnumerator SpawnWaves ()
	{
		while (true)
		{

			Vector3 spawnPosition = new Vector3 (Random.Range(startX, endX), roof, 0);
			Instantiate(rocket, spawnPosition, new Quaternion(0,0,0,0));
			updateScore(spawnScore);
	
			yield return new WaitForSeconds (1);
		}
	}

	IEnumerator ReloadRockets ()
	{
		while (true)
		{
			foreach (GameObject cannon in cannons) {
				cannon.GetComponent<Cannon>().increaseShots();
			
			}
			
			yield return new WaitForSeconds (2);
		}
	}

	public void destroyBuilding() {
		buildings --;
		if (buildings == 0) {
			Application.LoadLevel(Application.loadedLevel);
		}
	}

	public void updateScore(int score) {
		Spawner.score += score;
		text.text = "Score: " + Spawner.score;

	}
}


