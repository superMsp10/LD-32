using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
	public float moveSpeed;
	public GameM m;
	public Transform GroundCheck;
	public LayerMask whatGround;
	public bool grounded = false;
	public int jumpAmount;
	bool turnR;
	private Animator thisA;
	public bool attacking = false;
	public damage weapon;
	public float HP = 10;
	public Slider HP_slider;
	public GameObject[] bosyparts;
	Collider2D thisCollider;
	public GameObject particles;
	bool dead = false;

	void Start ()
	{
		thisA = GetComponent<Animator> ();
		HP_slider.maxValue = HP;
		HP_slider.value = HP;


	}

	public void takeDmg ()
	{
		HP--;
		HP_slider.value = HP;

	}
	void Update ()
	{
		if (Input.GetButtonDown ("Jump") && grounded) {
			rigidbody2D.velocity = new Vector2 (rigidbody2D.velocity.x, rigidbody2D.velocity.y + jumpAmount);
			
		}

		if (Input.GetButtonDown ("Fire1") && attacking == false) {
			thisA.SetTrigger ("Attack");
			weapon.attack = true;
			Invoke ("resetAt", 0.5f);
		}
		updateAnim ();

		if (HP < 0 && !dead) {
			die ();
		}
	}

	void die ()
	{
		dead = true;
		Instantiate (particles, transform.position, Quaternion.identity);
		foreach (GameObject g in bosyparts) {
			thisCollider = g.AddComponent<BoxCollider2D> ();
			g.AddComponent<Rigidbody2D> ();
			thisCollider.isTrigger = true;
			g.rigidbody2D.fixedAngle = false;
			g.rigidbody2D.velocity = new Vector2 (Random.Range (-5, 5) * moveSpeed, Random.Range (-10, 10) * moveSpeed);	
			g.rigidbody2D.AddTorque (Random.Range (-100, 100));
		}
		Destroy (gameObject, 2f);
	}

	void FixedUpdate ()
	{
		checkG ();
		float move = Input.GetAxis ("Horizontal");
		moveX (move);


	}



	void updateAnim ()
	{
		thisA.SetFloat ("hSpeed", Mathf.Abs (rigidbody2D.velocity.x));
		thisA.SetFloat ("vSpeed", rigidbody2D.velocity.y);



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
		if (other.gameObject.tag == "cash") {
			m.setCash ();
			Destroy (other.gameObject);
			
		}
		if (other.gameObject.tag == "chicken") {
			m.setleg ();
			Destroy (other.gameObject);
		}


	}
		
		
	public  void flip ()
	{
		turnR = !turnR;
		Vector3 scale = transform.localScale;
		scale.x *= -1;
		transform.localScale = scale;
	}



	void resetAt ()
	{

		attacking = false;
	}




}
