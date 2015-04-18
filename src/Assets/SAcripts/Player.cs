using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
	public float moveSpeed;
	public Transform GroundCheck;
	public LayerMask whatGround;
	public bool grounded = false;
	public int jumpAmount;



	void FixedUpdate ()
	{
		checkG ();
		float move = Input.GetAxis ("Horizontal");
		moveX (move);
		if (Input.GetButtonDown ("Jump") && grounded) {
			rigidbody2D.velocity = new Vector2 (rigidbody2D.velocity.x, rigidbody2D.velocity.y + jumpAmount);

		}

	}
	public  void moveX (float moveX)
	{
		float xMove = (moveX * 1);
		
		
	
		if (Mathf.Abs (rigidbody2D.velocity.x) < moveSpeed)
			rigidbody2D.velocity = new Vector2 (xMove + rigidbody2D.velocity.x, rigidbody2D.velocity.y);
		
	}

	void checkG ()
	{
		if (Physics2D.Linecast (transform.position, GroundCheck.position, whatGround)) {
			grounded = true;
		} else {
			grounded = false;
		}

	}

	void OnTriggerEnter2D (Collider2D other)
	{
		
		
	
		if (other.gameObject.tag == "boost") {
			collisionBoost thisBoost = other.gameObject.GetComponent<collisionBoost> ();
			if (thisBoost == null)
				Debug.LogError ("no collision boost script attached");
				
			thisBoost.boost (rigidbody2D);
		}
			
			
			
	}
		
		


}
