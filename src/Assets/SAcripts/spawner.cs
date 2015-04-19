using UnityEngine;
using System.Collections;

public class spawner : MonoBehaviour
{

	public GameObject[] spawn;
	public int amount;

	void OnTriggerEnter2D (Collider2D other)
	{
		for (int i = 0; i <Random.Range(1,amount); i++) {
			Invoke ("Ins", Random.Range (0f, 2f));
		}
		Destroy (gameObject, 3f);
	}

	void Ins ()
	{
		Debug.Log ("hi");

		Instantiate (spawn [Random.Range (0, spawn.Length)], transform.position, Quaternion.identity);

	}

}
