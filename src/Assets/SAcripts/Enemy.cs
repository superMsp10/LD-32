using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
	public float moveSpeed = 2f;		// The speed the enemy moves at.
	public int HP = 2;					// How many times the enemy can be hit before it dies.


	public float deathSpinMin = -100f;			// A value to give the minimum amount of Torque when dying
	public float deathSpinMax = 100f;			// A value to give the maximum amount of Torque when dying


	public Transform frontCheck;		// Reference to the position of the gameobject used for checking if something is in front.
	private bool dead = false;			// Whether or not the enemy is dead.
	public Collider2D thisCollider;
	public GameObject[] bosyparts;
	public GameObject particle;
	
	void Awake ()
	{
		// Setting up the references.
	}

	void FixedUpdate ()
	{
		// Create an array of all the colliders in front of the enemy.
		Collider2D[] frontHits = Physics2D.OverlapPointAll (frontCheck.position);

		// Check each of the colliders.
		foreach (Collider2D c in frontHits) {
			// If any of the colliders is an Obstacle...
			if (c.tag == "Obstacle") {
				// ... Flip the enemy and stop checking the other colliders.
				Flip ();
				break;
			}


		}

		// Set the enemy's velocity to moveSpeed in the x direction.
		rigidbody2D.velocity = new Vector2 (transform.localScale.x * moveSpeed, rigidbody2D.velocity.y);	

		// If the enemy has one hit point left and has a damagedEnemy sprite...

		if (HP <= 0 && !dead)
			Death ();
	}
	
	public void Hurt ()
	{
		// Reduce the number of hit points by one.
		HP--;
	}
	
	void Death ()
	{
		thisCollider.isTrigger = true;
		dead = true;
		Instantiate (particle, transform.position, Quaternion.identity);

		foreach (GameObject g in bosyparts) {
			thisCollider = g.AddComponent<BoxCollider2D> ();
			g.AddComponent<Rigidbody2D> ();
			thisCollider.isTrigger = true;
			g.rigidbody2D.fixedAngle = false;
			g.rigidbody2D.velocity = new Vector2 (Random.Range (-5, 5) * moveSpeed, Random.Range (-10, 10) * moveSpeed);	
			g.rigidbody2D.AddTorque (Random.Range (deathSpinMin, deathSpinMax));
		}


		Destroy (gameObject, 3f);

	}


	public void Flip ()
	{
		// Multiply the x component of localScale by -1.
		Vector3 enemyScale = transform.localScale;
		enemyScale.x *= -1;
		transform.localScale = enemyScale;
	}

	void OnCollisionStay2D (Collision2D c)
	{

		if (c.gameObject.tag == "Player") {
			Hurt ();
		}
	}
}
