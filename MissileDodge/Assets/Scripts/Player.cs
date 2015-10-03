using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
	[HideInInspector]
	public bool jump = false;				// Condition for whether the player should jump.
	
	
	public float moveForce = 365f;			// Amount of force added to move the player left and right.
	public float maxSpeed = 5f;				// The fastest the player can travel in the x axis.
	public float jumpForce = 1000f;			// Amount of force added when the player jumps.

	private Transform groundCheck;			// A position marking where to check if the player is grounded.
	private bool grounded = false;			// Whether or not the player is grounded.
	private bool inCannon = false;
	private Collider2D activeCannon;
	private Animator anim;
	bool facingRight = true;
	Rigidbody2D player;

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Cannon") {
			inCannon = true;
			activeCannon = other;
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		if (other.tag == "Cannon") {
			inCannon = false;
		}
	}
	void Awake()
	{
		// Setting up references.
		groundCheck = transform.Find("groundCheck");
		player = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
	}
	
	
	void Update()
	{



		if (Input.GetMouseButtonDown(0)) //when left button is clicked
		{

			if (inCannon) {
				activeCannon.GetComponent<Cannon>().fireShots();
				}

			}
	

		// The player is grounded if a linecast to the groundcheck position hits anything on the ground layer.
		grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));  
		
		// If the jump button is pressed and the player is grounded then the player should jump.
		if (Input.GetButtonDown ("Jump") && grounded) {
			jump = true;
			anim.SetBool("isGrounded", false);

		}
			

	}
	
	
	void FixedUpdate ()
	{
		// Cache the horizontal input.
		float h = Input.GetAxis("Horizontal");
		float j = Input.GetAxisRaw ("Horizontal");

		anim.SetFloat ("Speed", Mathf.Abs (h));

		if (h > 0 && !facingRight)
			Flip ();
		if (h < 0 && facingRight)
			Flip ();

		
		// If the player is changing direction (h has a different sign to velocity.x) or hasn't reached maxSpeed yet...
		if(h * GetComponent<Rigidbody2D>().velocity.x < maxSpeed)
			// ... add a force to the player.

			GetComponent<Rigidbody2D>().AddForce(Vector2.right * h * moveForce);
		
		// If the player's horizontal velocity is greater than the maxSpeed...
		if(Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x) > maxSpeed)
			// ... set the player's velocity to the maxSpeed in the x axis.

			GetComponent<Rigidbody2D>().velocity = new Vector2(Mathf.Sign(GetComponent<Rigidbody2D>().velocity.x) * maxSpeed, GetComponent<Rigidbody2D>().velocity.y);

		
		// If the player should jump...


		if(jump)
		{

					
			// Add a vertical force to the player.
			GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpForce));
			
			// Make sure the player can't jump again until the jump conditions from Update are satisfied.
			jump = false;
			anim.SetBool("isGrounded", true);
		}


	}
	
	void Flip() {
		facingRight = !facingRight;
		
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
	

}
