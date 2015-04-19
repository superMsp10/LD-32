using UnityEngine;
using System.Collections;

public class Resource : MonoBehaviour
{
	public GameObject madeOf;
	public bool destroyOnDrop = true;
	Rigidbody2D thisRigid;
	public int amount;
	public bool randomDrop;




	public void dropMadeOf ()
	{
		thisRigid = GetComponent<Rigidbody2D> ();
		if (randomDrop)
			amount = Random.Range (1, amount);
		for (int i = 0; i < amount; i++) {
			Vector3 pos = new Vector3 (gameObject.transform.position.x + Random.Range (0, 10)
			                          , gameObject.transform.position.y);
			GameObject g = (GameObject)Instantiate (madeOf, pos, Quaternion.identity);
						
			thisRigid.velocity.Set (-2, 5);
		}
		if (destroyOnDrop)
			Destroy (this.gameObject);

	}
}

