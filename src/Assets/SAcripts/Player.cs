using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
	public float moveSpeed;
	public Transform GroundCheck;
	public LayerMask whatGround;
	public bool grounded = false;
	public int jumpAmount;
	bool turnR;
	void Update ()
	{
		if (Input.GetButtonDown ("Jump") && grounded) {
			rigidbody2D.velocity = new Vector2 (rigidbody2D.velocity.x, rigidbody2D.velocity.y + jumpAmount);
			
		}

	}

	void FixedUpdate ()
	{
		checkG ();
		float move = Input.GetAxis ("Horizontal");
		moveX (move);


	}
	public  void moveX (float moveX)
	{
		float xMove = (moveX);
		
		if (xMove < 0 && turnR) {
			flip ();
		} else if (xMove > 0 && !turnR) {
			flip ();
		}
	
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
		
		
	public virtual void flip ()
	{
		turnR = !turnR;
		Vector3 scale = transform.localScale;
		scale.x *= -1;
		transform.localScale = scale;
	}

}
