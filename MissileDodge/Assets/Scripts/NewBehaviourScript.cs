using UnityEngine;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0)) //when left button is clicked
        {
            // todo if char is on controlPanel
            Vector3 p = Input.mousePosition;
            Rigidbody2D rocketInstance = Instantiate(rocket, transform.position, Quaternion.Euler(p));
            rocketInstance.velocity = new Vector2(1, 0); //nz ko praqt teq value-ta na vactor2 ama sh stani
        }
	}
}
