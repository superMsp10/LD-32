using UnityEngine;
using System.Collections;

public class damage : MonoBehaviour
{
	public bool attack ;
	void OnTriggerEnter2D (Collider2D other)
	{
		
		
		if (other.gameObject.tag == "enemy") {
			if (attack)
				other.gameObject.GetComponent<Enemy> ().Hurt (5);
		}
		
		
		
	}
}
